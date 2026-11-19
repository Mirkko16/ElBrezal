using ElBrezal.Application.Calculations;
using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Application.Models.ARCA;
using ElBrezal.Infrastructure.ARCA;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;

namespace ElBrezal.Infrastructure.Services
{
    public class ComprobanteAutorizacionService : IComprobanteAutorizacionService
    {

        private readonly ElBrezalDbContext _context;
        private readonly IArcaCredencialesService _arcaCredencialesService;
        private readonly IArcaFacturacionService _arcaFacturacionService;

        /// <summary>
        /// Inicializa el servicio de autorización de comprobantes.
        /// </summary>
        public ComprobanteAutorizacionService(
            ElBrezalDbContext context,
            IArcaCredencialesService arcaCredencialesService,
            IArcaFacturacionService arcaFacturacionService)
        {
            _context = context;
            _arcaCredencialesService = arcaCredencialesService;
            _arcaFacturacionService = arcaFacturacionService;
        }



        /// <summary>
        /// Autoriza un comprobante fiscal ante ARCA.
        /// Reserva su identificación fiscal antes de solicitar el CAE
        /// y conserva la solicitud original para permitir su recuperación.
        /// </summary>
        public async Task<ArcaResultadoCaeDto> AutorizarAsync(
            int comprobanteId,
            CancellationToken cancellationToken = default)
        {
            // 1. Recuperar el comprobante y sus datos fiscales.
            var comprobante = await _context.Comprobantes
                .AsNoTracking()
                .Include(x => x.TipoComprobante)
                .Include(x => x.SituacionImpositiva)
                .Include(x => x.Cliente)
                .Include(x => x.ComprobantesDetalle)
                    .ThenInclude(x => x.AlicuotaIVA)
                .SingleOrDefaultAsync(
                    x => x.Id == comprobanteId,
                    cancellationToken);

            if (comprobante == null)
                throw new InvalidOperationException(
                    "No se encontró el comprobante.");

            if (comprobante.Anulado)
                throw new InvalidOperationException(
                    "No se puede autorizar un comprobante anulado.");

            if (comprobante.ArcaNumero.HasValue ||
                !string.IsNullOrWhiteSpace(comprobante.CAE))
            {
                throw new InvalidOperationException(
                    "El comprobante ya tiene una reserva o autorización fiscal. " +
                    "Debe consultarse su estado antes de intentar otra emisión.");
            }

            int tipoArca = comprobante.TipoComprobante.CodigoArca
                ?? throw new InvalidOperationException(
                    "El tipo de comprobante no es fiscal.");

            // Por ahora implementamos emisión de facturas A y B.
            if (tipoArca != 1 && tipoArca != 6)
            {
                throw new NotSupportedException(
                    "Esta etapa admite solamente Facturas A y B.");
            }

            int puntoVenta = comprobante.PuntoVenta;

            if (puntoVenta <= 0)
                throw new InvalidOperationException(
                    "El punto de venta no es válido.");

            // Política conservadora para esta primera emisión:
            // exigimos identificar al receptor.
            var (docTipo, docNro) =
                ResolverDocumentoReceptor(
                    comprobante,
                    requiereIdentificacion: true);

            // Validamos los importes antes de reservar un número.
            CalcularImportesFiscales(comprobante);

            // 2. Recuperar configuración fiscal.
            var config = await _context.Config
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken)
                ?? throw new InvalidOperationException(
                    "No se encontró la configuración del sistema.");

            if (!config.FacturacionElectronica)
                throw new InvalidOperationException(
                    "La facturación electrónica está deshabilitada.");

            string ambiente = config.AmbienteArca?
                .Trim()
                .ToUpperInvariant()
                ?? string.Empty;

            long cuitEmisor = ResolverCuitEmisor(
                ambiente,
                config.CUIT);

            string rutaPfx =
                config.RutaCertificadoPfx?.Trim()
                ?? string.Empty;

            if (string.IsNullOrWhiteSpace(rutaPfx))
                throw new InvalidOperationException(
                    "No se configuró el certificado PFX.");

            var auth = await _arcaCredencialesService
                .ObtenerCredencialesValidasAsync(
                    cuitEmisor,
                    ambiente,
                    rutaPfx,
                    cancellationToken: cancellationToken);

            // 3. Reservar número y solicitud bajo bloqueo SQL.
            ArcaSolicitudCaeDto solicitud;

            await using (var transaction =
                await _context.Database.BeginTransactionAsync(
                    IsolationLevel.ReadCommitted,
                    cancellationToken))
            {
                string recurso =
                    $"ARCA:{cuitEmisor}:{ambiente}:{puntoVenta}:{tipoArca}";

                var conexion = _context.Database.GetDbConnection();

                await using (var comando = conexion.CreateCommand())
                {
                    comando.Transaction = transaction.GetDbTransaction();

                    comando.CommandText = """
                DECLARE @resultado INT;

                EXEC @resultado = sys.sp_getapplock
                    @Resource = @recurso,
                    @LockMode = 'Exclusive',
                    @LockOwner = 'Transaction',
                    @LockTimeout = 15000;

                SELECT @resultado;
                """;

                    var parametro = comando.CreateParameter();
                    parametro.ParameterName = "@recurso";
                    parametro.Value = recurso;
                    comando.Parameters.Add(parametro);

                    int bloqueo = Convert.ToInt32(
                        await comando.ExecuteScalarAsync(cancellationToken));

                    if (bloqueo < 0)
                        throw new InvalidOperationException(
                            "No se pudo bloquear la numeración fiscal.");
                }

                // Releer después de adquirir el bloqueo.
                var registro = await _context.Comprobantes
                    .SingleOrDefaultAsync(
                        x => x.Id == comprobanteId,
                        cancellationToken)
                    ?? throw new InvalidOperationException(
                        "El comprobante dejó de estar disponible.");

                await _context.Entry(registro)
                    .ReloadAsync(cancellationToken);

                if (registro.Anulado ||
                    registro.ArcaNumero.HasValue ||
                    !string.IsNullOrWhiteSpace(registro.CAE))
                {
                    throw new InvalidOperationException(
                        "El comprobante ya fue anulado, reservado o autorizado.");
                }

                // Una reserva sin resolver puede representar una
                // emisión aceptada cuya respuesta todavía no recibimos.
                bool existeReservaPendiente = await _context.Comprobantes
                    .AsNoTracking()
                    .AnyAsync(
                        x => x.Id != comprobanteId
                            && x.ArcaCUITEmisor == cuitEmisor
                            && x.ArcaAmbiente == ambiente
                            && x.ArcaPuntoVenta == puntoVenta
                            && x.ArcaTipoComprobante == tipoArca
                            && x.ArcaNumero != null
                            && x.ArcaEstado != "AUTORIZADO",
                        cancellationToken);

                if (existeReservaPendiente)
                {
                    throw new InvalidOperationException(
                        "Existen reservas fiscales sin resolver para este " +
                        "tipo y punto de venta. Consultalas antes de emitir.");
                }

                // 4. Consultar el último autorizado en ARCA
                // mientras conservamos el bloqueo lógico.
                var ultimo = await _arcaFacturacionService
                    .ObtenerUltimoComprobanteAutorizadoAsync(
                        auth,
                        cuitEmisor,
                        ambiente,
                        puntoVenta,
                        tipoArca,
                        cancellationToken);

                if (ultimo.PuntoVenta != puntoVenta ||
                    ultimo.TipoComprobante != tipoArca ||
                    ultimo.UltimoNumero < 0)
                {
                    throw new InvalidOperationException(
                        "ARCA devolvió una numeración inconsistente.");
                }

                long numeroFiscal = checked(ultimo.UltimoNumero + 1);

                bool reservado = await _context.Comprobantes
                    .AsNoTracking()
                    .AnyAsync(
                        x => x.Id != comprobanteId
                            && x.ArcaCUITEmisor == cuitEmisor
                            && x.ArcaAmbiente == ambiente
                            && x.ArcaPuntoVenta == puntoVenta
                            && x.ArcaTipoComprobante == tipoArca
                            && x.ArcaNumero == numeroFiscal,
                        cancellationToken);

                if (reservado)
                    throw new InvalidOperationException(
                        $"El número fiscal {numeroFiscal} ya está reservado.");

                solicitud = ConstruirSolicitudCae(
                    comprobante,
                    numeroFiscal,
                    docTipo,
                    docNro);

                // Verificar que el DTO coincida con la identidad
                // fiscal que vamos a persistir.
                if (solicitud.PuntoVenta != puntoVenta ||
                    solicitud.TipoComprobante != tipoArca ||
                    solicitud.Numero != numeroFiscal)
                {
                    throw new InvalidOperationException(
                        "La solicitud no coincide con la reserva fiscal.");
                }

                registro.ArcaCUITEmisor = cuitEmisor;
                registro.ArcaAmbiente = ambiente;
                registro.ArcaPuntoVenta = puntoVenta;
                registro.ArcaTipoComprobante = tipoArca;
                registro.ArcaNumero = numeroFiscal;

                registro.ArcaSolicitudJson =
                    JsonSerializer.Serialize(solicitud);

                registro.ArcaEstado = "EN_PROCESO";
                registro.ArcaUltimoError = null;
                registro.ArcaUltimoIntento = DateTime.Now;
                registro.ArcaCantidadIntentos++;

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }

            // La reserva ya está confirmada en SQL Server.
            // A partir de aquí no se asigna otro número fiscal.


            // La reserva fiscal ya fue confirmada en SQL Server.
            // No se debe asignar otro número al mismo comprobante.

            ArcaResultadoCaeDto resultado;

            try
            {
                resultado = await _arcaFacturacionService
                    .SolicitarCaeAsync(
                        auth,
                        cuitEmisor,
                        ambiente,
                        solicitud,
                        cancellationToken);
            }
            catch (Exception ex)
            {
                // No podemos asegurar que ARCA no haya procesado
                // la solicitud. Conservamos la reserva fiscal.
                await MarcarRespuestaInciertaAsync(
                    comprobanteId,
                    $"No se pudo confirmar la respuesta de ARCA: {ex.Message}");

                throw new InvalidOperationException(
                    "El resultado de la autorización es incierto. " +
                    "La numeración fiscal permanece reservada. " +
                    "Consultá el comprobante en ARCA antes de reintentar.",
                    ex);
            }

            // Validar la identidad de la respuesta.
            if (resultado.PuntoVenta != solicitud.PuntoVenta ||
                resultado.TipoComprobante != solicitud.TipoComprobante ||
                resultado.Numero != solicitud.Numero)
            {
                await MarcarRespuestaInciertaAsync(
                    comprobanteId,
                    "La identificación fiscal de la respuesta no coincide " +
                    "con la solicitud original.");

                throw new InvalidOperationException(
                    "ARCA devolvió una identificación fiscal inconsistente. " +
                    "La reserva se conserva para su recuperación.");
            }

            string observaciones = string.Join(
                " | ",
                resultado.Observaciones.Concat(resultado.Errores));

            // Una respuesta aprobada debe contener CAE y vencimiento.
            bool autorizacionCompleta =
                resultado.Aprobado &&
                resultado.CAEVencimiento.HasValue;

            // Solamente consideramos definitivo un rechazo
            // explícito informado por ARCA.
            bool rechazoExplicito =
                resultado.Resultado == "R" &&
                string.IsNullOrWhiteSpace(resultado.CAE);

            string estadoFinal;
            string? ultimoError;

            if (autorizacionCompleta)
            {
                estadoFinal = "AUTORIZADO";
                ultimoError = null;
            }
            else if (rechazoExplicito)
            {
                estadoFinal = "RECHAZADO";
                ultimoError = string.IsNullOrWhiteSpace(observaciones)
                    ? "ARCA rechazó explícitamente la solicitud."
                    : observaciones;
            }
            else
            {
                estadoFinal = "SIN_RESPUESTA";
                ultimoError =
                    "ARCA devolvió una respuesta incompleta o no concluyente.";
            }

            // Persistir el resultado. Si falla el guardado, el
            // comprobante conserva su reserva fiscal original.
            try
            {
                int registrosActualizados = await _context.Comprobantes
                    .Where(x =>
                        x.Id == comprobanteId &&
                        x.ArcaCUITEmisor == cuitEmisor &&
                        x.ArcaAmbiente == ambiente &&
                        x.ArcaPuntoVenta == solicitud.PuntoVenta &&
                        x.ArcaTipoComprobante == solicitud.TipoComprobante &&
                        x.ArcaNumero == solicitud.Numero &&
                        x.ArcaEstado == "EN_PROCESO")
                    .ExecuteUpdateAsync(
                        setters => setters
                            .SetProperty(
                                x => x.ArcaEstado,
                                estadoFinal)
                            .SetProperty(
                                x => x.ArcaUltimoError,
                                ultimoError)
                            .SetProperty(
                                x => x.ArcaObservaciones,
                                observaciones)
                            .SetProperty(
                                x => x.CAE,
                                autorizacionCompleta ? resultado.CAE : null)
                            .SetProperty(
                                x => x.CAEVencimiento,
                                autorizacionCompleta
                                    ? resultado.CAEVencimiento
                                    : null)
                            .SetProperty(
                                x => x.ArcaFechaAutorizacion,
                                autorizacionCompleta
                                    ? DateTime.Now
                                    : (DateTime?)null),
                        CancellationToken.None);

                if (registrosActualizados != 1)
                {
                    throw new InvalidOperationException(
                        "No se pudo confirmar la actualización del " +
                        "comprobante fiscal. Revisá su estado.");
                }
            }
            catch (Exception ex)
            {
                // Puede existir un CAE válido en ARCA aunque
                // su persistencia local haya fallado.
                throw new InvalidOperationException(
                    "Se recibió una respuesta de ARCA, pero no se pudo " +
                    "confirmar su registro local. " +
                    "No vuelvas a emitir: consultá la autorización existente.",
                    ex);
            }

            if (estadoFinal == "SIN_RESPUESTA")
            {
                throw new InvalidOperationException(
                    "ARCA devolvió una respuesta no concluyente. " +
                    "La solicitud permanece reservada y debe consultarse.");
            }

            return resultado;
        
        }



        /// <summary>
        /// Consulta en ARCA la autorización de un comprobante existente.
        /// Si se confirma el CAE, actualiza los datos fiscales locales.
        /// </summary>
        /// <param name="comprobanteId">
        /// Identificador interno del comprobante.
        /// </param>
        /// <param name="cancellationToken">
        /// Token de cancelación de la operación.
        /// </param>
        /// <returns>
        /// Resultado de ARCA o null cuando se confirma que
        /// el comprobante consultado no existe.
        /// </returns>

        /// <summary>
        /// Consulta ante ARCA la autorización de un comprobante existente.
        /// Verifica su identificación fiscal y los datos devueltos antes
        /// de recuperar y persistir el CAE.
        /// </summary>
        /// <param name="comprobanteId">
        /// Identificador interno del comprobante.
        /// </param>
        /// <param name="cancellationToken">
        /// Token de cancelación de la operación.
        /// </param>
        /// <returns>
        /// Resultado de la consulta o null cuando ARCA confirma
        /// que el comprobante no existe.
        /// </returns>
        public async Task<ArcaResultadoCaeDto?> ConsultarAutorizacionAsync(
            int comprobanteId,
            CancellationToken cancellationToken = default)
        {
            // 1. Recuperar el comprobante local.
            var comprobante = await _context.Comprobantes
                .FirstOrDefaultAsync(
                    x => x.Id == comprobanteId,
                    cancellationToken);

            if (comprobante == null)
            {
                throw new InvalidOperationException(
                    "No se encontró el comprobante solicitado.");
            }

            if (comprobante.Anulado)
            {
                throw new InvalidOperationException(
                    "No se puede consultar un comprobante anulado.");
            }

            if (comprobante.ArcaEstado == "AUTORIZADO" &&
                !string.IsNullOrWhiteSpace(comprobante.CAE))
            {
                throw new InvalidOperationException(
                    "El comprobante ya tiene un CAE registrado.");
            }

            // 2. Verificar la identificación fiscal original.
            if (!comprobante.ArcaCUITEmisor.HasValue ||
                string.IsNullOrWhiteSpace(comprobante.ArcaAmbiente) ||
                !comprobante.ArcaPuntoVenta.HasValue ||
                !comprobante.ArcaTipoComprobante.HasValue ||
                !comprobante.ArcaNumero.HasValue)
            {
                throw new InvalidOperationException(
                    "El comprobante no tiene una identificación fiscal " +
                    "ARCA completa. No es seguro utilizar su numeración interna.");
            }

            long cuit = comprobante.ArcaCUITEmisor.Value;
            string ambiente =
                comprobante.ArcaAmbiente.Trim().ToUpperInvariant();

            int puntoVenta = comprobante.ArcaPuntoVenta.Value;
            int tipoComprobante = comprobante.ArcaTipoComprobante.Value;
            long numero = comprobante.ArcaNumero.Value;

            if (cuit <= 0 ||
                puntoVenta <= 0 ||
                tipoComprobante <= 0 ||
                numero <= 0)
            {
                throw new InvalidOperationException(
                    "La identificación fiscal contiene valores inválidos.");
            }

            // 3. Recuperar la configuración activa.
            var config = await _context.Config
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);

            if (config == null)
            {
                throw new InvalidOperationException(
                    "No se encontró la configuración del sistema.");
            }

            if (!config.FacturacionElectronica)
            {
                throw new InvalidOperationException(
                    "La facturación electrónica está deshabilitada.");
            }

            string ambienteConfigurado =
                config.AmbienteArca.Trim().ToUpperInvariant();

            long cuitConfigurado = ResolverCuitEmisor(
                ambienteConfigurado,
                config.CUIT);

            if (cuit != cuitConfigurado ||
                ambiente != ambienteConfigurado)
            {
                throw new InvalidOperationException(
                    "El CUIT o ambiente del comprobante no coincide " +
                    "con la configuración fiscal de esta instalación.");
            }

            string rutaPfx =
                config.RutaCertificadoPfx?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(rutaPfx))
            {
                throw new InvalidOperationException(
                    "No se configuró la ruta del certificado PFX.");
            }

            // 4. Recuperar las credenciales WSAA.
            var auth = await _arcaCredencialesService
                .ObtenerCredencialesValidasAsync(
                    cuit,
                    ambiente,
                    rutaPfx,
                    cancellationToken: cancellationToken);

            // 5. Consultar el comprobante fiscal en ARCA.
            var resultado = await _arcaFacturacionService
                .ConsultarComprobanteAsync(
                    auth,
                    cuit,
                    ambiente,
                    puntoVenta,
                    tipoComprobante,
                    numero,
                    cancellationToken);

            // No encontrado no equivale a rechazado.
            if (resultado == null)
            {
                return null;
            }

            // 6. Validar identificación fiscal.
            if (resultado.PuntoVenta != puntoVenta ||
                resultado.TipoComprobante != tipoComprobante ||
                resultado.Numero != numero)
            {
                throw new InvalidOperationException(
                    "ARCA devolvió una identificación fiscal diferente " +
                    "a la del comprobante consultado.");
            }

            // Si no existe una autorización completa, no persistimos CAE.
            if (!resultado.Aprobado ||
                string.IsNullOrWhiteSpace(resultado.CAE) ||
                !resultado.CAEVencimiento.HasValue)
            {
                return resultado;
            }

            // 7. Verificar fecha e importe.
            if (!resultado.FechaComprobante.HasValue)
            {
                throw new InvalidOperationException(
                    "ARCA no devolvió la fecha del comprobante. " +
                    "No se puede confirmar la autorización.");
            }

            if (!resultado.ImporteTotal.HasValue)
            {
                throw new InvalidOperationException(
                    "ARCA no devolvió el importe total del comprobante. " +
                    "No se puede confirmar la autorización.");
            }

            DateOnly fechaLocal =
                DateOnly.FromDateTime(comprobante.Fecha);

            if (resultado.FechaComprobante.Value != fechaLocal)
            {
                throw new InvalidOperationException(
                    "La fecha del comprobante informado por ARCA " +
                    "no coincide con la registrada en ElBrezal.");
            }

            if (Math.Abs(
                resultado.ImporteTotal.Value - comprobante.Total) > 0.01m)
            {
                throw new InvalidOperationException(
                    "El importe total informado por ARCA no coincide " +
                    "con el comprobante registrado en ElBrezal.");
            }

            // 8. Verificar disponibilidad del documento receptor.
            if (!resultado.TipoDocumentoReceptor.HasValue ||
                !resultado.NumeroDocumentoReceptor.HasValue)
            {
                throw new InvalidOperationException(
                    "ARCA no devolvió los datos del documento receptor. " +
                    "No se puede confirmar la autorización.");
            }


            if (string.IsNullOrWhiteSpace(comprobante.ArcaSolicitudJson))
            {
                throw new InvalidOperationException(
                    "No existe la solicitud fiscal original para verificar el CAE.");
            }

            var solicitudOriginal =
                JsonSerializer.Deserialize<ArcaSolicitudCaeDto>(
                    comprobante.ArcaSolicitudJson)
                ?? throw new InvalidOperationException(
                    "No se pudo recuperar la solicitud fiscal original.");

            if (solicitudOriginal.PuntoVenta != puntoVenta ||
                solicitudOriginal.TipoComprobante != tipoComprobante ||
                solicitudOriginal.Numero != numero ||
                solicitudOriginal.DocTipo != resultado.TipoDocumentoReceptor ||
                solicitudOriginal.DocNro != resultado.NumeroDocumentoReceptor ||
                solicitudOriginal.Fecha != resultado.FechaComprobante ||
                Math.Abs(
                    solicitudOriginal.ImporteTotal -
                    resultado.ImporteTotal!.Value) > 0.01m)
            {
                throw new InvalidOperationException(
                    "Los datos fiscales recuperados de ARCA no coinciden " +
                    "con la solicitud original. No se registró el CAE.");
            }

            comprobante.CAE = resultado.CAE;
            comprobante.CAEVencimiento = resultado.CAEVencimiento;
            comprobante.ArcaFechaAutorizacion = DateTime.Now;
            comprobante.ArcaEstado = "AUTORIZADO";
            comprobante.ArcaUltimoError = null;

            comprobante.ArcaObservaciones =
                string.Join(" | ", resultado.Observaciones);

            await _context.SaveChangesAsync(cancellationToken);

            return resultado;

        }



        public async Task<List<ComprobantePendienteDto>>
            ObtenerPendientesAsync(
                CancellationToken cancellationToken = default)
        {
            var estadosPendientes = new[]
            {
                "PENDIENTE",
                "RECHAZADO",
                "SIN_RESPUESTA",
                "EN_PROCESO"
            };

            var comprobantes = await (
                from comprobante in _context.Comprobantes.AsNoTracking()

                join tipo in _context.TiposComprobante.AsNoTracking()
                    on comprobante.TipoComprobanteId equals tipo.Id

                join cliente in _context.Clientes.AsNoTracking()
                    on comprobante.ClienteId equals cliente.Id

                where !comprobante.Anulado
                    && tipo.CodigoArca != null
                    && estadosPendientes.Contains(comprobante.ArcaEstado!)

                orderby comprobante.Fecha descending,
                        comprobante.Id descending

                select new ComprobantePendienteDto
                {
                    Id = comprobante.Id,
                    Fecha = comprobante.Fecha,
                    TipoComprobante = tipo.Nombre,
                    PuntoVenta = comprobante.PuntoVenta,
                    Numero = comprobante.Numero,
                    Cliente = cliente.Nombre,
                    Total = comprobante.Total,
                    Estado = comprobante.ArcaEstado!,
                    UltimoError = comprobante.ArcaUltimoError,
                    CantidadIntentos = comprobante.ArcaCantidadIntentos,
                    UltimoIntento = comprobante.ArcaUltimoIntento
                }
            ).ToListAsync(cancellationToken);

            return comprobantes;
        }


        /// <summary>
        /// Obtiene el CUIT emisor correspondiente al ambiente
        /// configurado para esta instalación.
        /// </summary>
        private static long ResolverCuitEmisor(
            string ambiente,
            long cuitNegocio)
        {
            if (ambiente == "PRODUCCION")
                return cuitNegocio;

            if (ambiente == "HOMOLOGACION")
            {
                string? valor = Environment.GetEnvironmentVariable(
                    "ELBREZAL_ARCA_CUIT_HOMOLOGACION");

                if (!long.TryParse(valor, out long cuitHomologacion) ||
                    cuitHomologacion <= 0)
                {
                    throw new InvalidOperationException(
                        "No se configuró el CUIT de homologación. " +
                        "Verificá la variable de entorno " +
                        "ELBREZAL_ARCA_CUIT_HOMOLOGACION.");
                }

                return cuitHomologacion;
            }

            throw new InvalidOperationException(
                $"Ambiente ARCA no reconocido: {ambiente}");
        }

        /// <summary>
        /// Calcula el desglose fiscal de un comprobante persistido,
        /// utilizando los importes y porcentajes históricos de IVA.
        /// </summary>
        private static ComprobanteFiscalResultado CalcularImportesFiscales(
            Comprobantes comprobante)
        {
            ArgumentNullException.ThrowIfNull(comprobante);

            if (comprobante.ComprobantesDetalle.Count == 0)
            {
                throw new InvalidOperationException(
                    "El comprobante no contiene detalles.");
            }

            var detallesFiscales = new List<ComprobanteFiscalDetalle>();

            foreach (var detalle in comprobante.ComprobantesDetalle)
            {
                if (!detalle.AlicuotaIVAId.HasValue ||
                    !detalle.PorcentajeIVA.HasValue ||
                    detalle.AlicuotaIVA is null)
                {
                    throw new InvalidOperationException(
                        $"El detalle {detalle.Id} no tiene una alícuota de IVA válida.");
                }

                if (!detalle.AlicuotaIVA.CodigoArca.HasValue)
                {
                    throw new InvalidOperationException(
                        $"La alícuota de IVA del detalle {detalle.Id} " +
                        "no tiene código ARCA configurado.");
                }

                // En el catálogo actual, el código ARCA 3
                // corresponde al tratamiento EXENTO.
                bool esExento = detalle.AlicuotaIVA.CodigoArca.Value == 3;

                detallesFiscales.Add(new ComprobanteFiscalDetalle
                {
                    Importe = detalle.Importe,
                    PorcentajeIVA = detalle.PorcentajeIVA.Value,
                    CodigoArcaIVA = detalle.AlicuotaIVA.CodigoArca.Value,
                    EsExento = esExento
                });
            }

            return ComprobanteFiscalCalculations.Calcular(
                detallesFiscales,
                comprobante.MontoVariacion,
                comprobante.Total);
        }


        /// <summary>
        /// Construye la solicitud fiscal de ARCA a partir de un
        /// comprobante persistido y su numeración fiscal reservada.
        /// </summary>
        private static ArcaSolicitudCaeDto ConstruirSolicitudCae(
            Comprobantes comprobante,
            long numeroFiscal,
            int docTipo,
            long docNro)
        {
            ArgumentNullException.ThrowIfNull(comprobante);

            if (!comprobante.TipoComprobante.CodigoArca.HasValue)
            {
                throw new InvalidOperationException(
                    "El tipo de comprobante no tiene código ARCA configurado.");
            }

            if (!comprobante.SituacionImpositiva.CodigoArca.HasValue)
            {
                throw new InvalidOperationException(
                    "La situación impositiva no tiene código ARCA configurado.");
            }

            if (numeroFiscal <= 0)
            {
                throw new InvalidOperationException(
                    "El número fiscal debe ser mayor a cero.");
            }

            if (docTipo <= 0 || docNro < 0)
            {
                throw new InvalidOperationException(
                    "El documento del receptor no es válido.");
            }

            var fiscal = CalcularImportesFiscales(comprobante);

            return new ArcaSolicitudCaeDto
            {
                PuntoVenta = comprobante.PuntoVenta,
                TipoComprobante =
                    comprobante.TipoComprobante.CodigoArca.Value,

                Numero = numeroFiscal,
                Fecha = DateOnly.FromDateTime(comprobante.Fecha),

                Concepto = 1,

                DocTipo = docTipo,
                DocNro = docNro,

                CondicionIvaReceptorId =
                    comprobante.SituacionImpositiva.CodigoArca.Value,

                ImporteTotal = fiscal.ImporteTotal,
                ImporteNeto = fiscal.ImporteNeto,
                ImporteNoGravado = fiscal.ImporteNoGravado,
                ImporteExento = fiscal.ImporteExento,
                ImporteIVA = fiscal.ImporteIVA,
                ImporteTributos = fiscal.ImporteTributos,

                AlicuotasIVA = fiscal.AlicuotasIVA
                    .Select(x => new ArcaAlicuotaIvaDto
                    {
                        Id = x.CodigoArcaIVA,
                        BaseImponible = x.BaseImponible,
                        Importe = x.ImporteIVA
                    })
                    .ToList()
            };
        }


        /// <summary>
        /// Resuelve el tipo y número de documento del receptor
        /// para una Factura A o B.
        /// Permite consumidores finales sin identificar cuando
        /// las reglas fiscales de la operación lo admiten.
        /// </summary>
        private static (int DocTipo, long DocNro) ResolverDocumentoReceptor(
            Comprobantes comprobante,
            bool requiereIdentificacion)
        {
            ArgumentNullException.ThrowIfNull(comprobante);

            if (comprobante.Cliente is null)
            {
                throw new InvalidOperationException(
                    "No se cargaron los datos del cliente.");
            }

            int codigoComprobante = comprobante.TipoComprobante.CodigoArca
                ?? throw new InvalidOperationException(
                    "El comprobante no tiene código ARCA.");

            int codigoSituacion = comprobante.SituacionImpositiva.CodigoArca
                ?? throw new InvalidOperationException(
                    "La situación impositiva no tiene código ARCA.");

            string cuit = new string(
                (comprobante.Cliente.CUIT ?? string.Empty)
                .Where(char.IsDigit)
                .ToArray());

            string dni = new string(
                (comprobante.Cliente.DNI ?? string.Empty)
                .Where(char.IsDigit)
                .ToArray());

            // Factura A: requiere CUIT del receptor.
            if (codigoComprobante == 1)
            {
                if (!ValidarCuit(cuit))
                {
                    throw new InvalidOperationException(
                        "La Factura A requiere un CUIT válido.");
                }

                return (80, long.Parse(cuit));
            }

            // Por ahora solamente contemplamos Factura B.
            if (codigoComprobante != 6)
            {
                throw new InvalidOperationException(
                    "La resolución de documentos todavía no está " +
                    "implementada para este tipo de comprobante.");
            }

            // Si se informó CUIT, debe ser válido.
            if (!string.IsNullOrEmpty(cuit))
            {
                if (!ValidarCuit(cuit))
                {
                    throw new InvalidOperationException(
                        "El CUIT informado no es válido.");
                }

                return (80, long.Parse(cuit));
            }

            // Si se informó DNI, debe ser válido.
            if (!string.IsNullOrEmpty(dni))
            {
                if (dni.Length < 7 ||
                    dni.Length > 8 ||
                    !long.TryParse(dni, out long numeroDni) ||
                    numeroDni <= 0)
                {
                    throw new InvalidOperationException(
                        "El DNI informado no es válido.");
                }

                return (96, numeroDni);
            }

            // Código 5: Consumidor Final en nuestro catálogo ARCA.
            bool esConsumidorFinal = codigoSituacion == 5;

            if (!esConsumidorFinal || requiereIdentificacion)
            {
                throw new InvalidOperationException(
                    "La operación requiere identificar al receptor " +
                    "mediante un documento válido.");
            }

            // Consumidor Final no identificado.
            return (99, 0);
        }

        /// <summary>
        /// Verifica el dígito de control de un CUIT argentino.
        /// </summary>
        private static bool ValidarCuit(string cuit)
        {
            if (cuit.Length != 11 || !cuit.All(char.IsDigit))
                return false;

            int[] multiplicadores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

            int suma = 0;

            for (int i = 0; i < 10; i++)
            {
                suma += (cuit[i] - '0') * multiplicadores[i];
            }

            int resto = suma % 11;

            int digitoVerificador = resto switch
            {
                0 => 0,
                1 => 9,
                _ => 11 - resto
            };

            return digitoVerificador == cuit[10] - '0';
        }

        /// <summary>
        /// Reserva de forma transaccional la identificación fiscal de un comprobante.
        /// Evita reservas concurrentes para el mismo CUIT, ambiente,
        /// punto de venta y tipo de comprobante.
        /// </summary>
        private async Task ReservarNumeroFiscalAsync(int comprobanteId, long cuitEmisor,
            string ambiente, int puntoVenta, int tipoComprobante, long numeroFiscal,
            ArcaSolicitudCaeDto solicitud,
            CancellationToken cancellationToken = default)
        {
            if (numeroFiscal <= 0)
            {
                throw new ArgumentException(
                    "El número fiscal debe ser mayor a cero.");
            }

            string recursoBloqueo =
                $"ARCA:{cuitEmisor}:{ambiente}:{puntoVenta}:{tipoComprobante}";

            await using var transaction =
                await _context.Database.BeginTransactionAsync(
                    IsolationLevel.ReadCommitted,
                    cancellationToken);

            // Bloqueo exclusivo asociado a la transacción SQL Server.
            var conexion = _context.Database.GetDbConnection();

            await using var comando = conexion.CreateCommand();

            comando.Transaction =
                transaction.GetDbTransaction();

            comando.CommandText = """
        DECLARE @resultado INT;

        EXEC @resultado = sp_getapplock
            @Resource = @recurso,
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 15000;

        SELECT @resultado;
        """;

            var parametro = comando.CreateParameter();
            parametro.ParameterName = "@recurso";
            parametro.Value = recursoBloqueo;
            comando.Parameters.Add(parametro);

            int resultadoBloqueo = Convert.ToInt32(
                await comando.ExecuteScalarAsync(cancellationToken));

            if (resultadoBloqueo < 0)
            {
                throw new InvalidOperationException(
                    "No se pudo obtener el bloqueo de numeración fiscal.");
            }

            // Recuperar el comprobante dentro de la transacción.
            var comprobante = await _context.Comprobantes
                .FirstOrDefaultAsync(
                    x => x.Id == comprobanteId,
                    cancellationToken);

            if (comprobante == null)
            {
                throw new InvalidOperationException(
                    "No se encontró el comprobante.");
            }

            if (comprobante.Anulado)
            {
                throw new InvalidOperationException(
                    "No se puede autorizar un comprobante anulado.");
            }

            if (comprobante.ArcaNumero.HasValue)
            {
                throw new InvalidOperationException(
                    "El comprobante ya tiene un número fiscal reservado. " +
                    "Debe resolverse la solicitud existente.");
            }

            if (!string.IsNullOrWhiteSpace(comprobante.CAE))
            {
                throw new InvalidOperationException(
                    "El comprobante ya tiene un CAE registrado.");
            }

            // Verificar que la solicitud corresponda a la reserva.
            if (solicitud.PuntoVenta != puntoVenta ||
                solicitud.TipoComprobante != tipoComprobante ||
                solicitud.Numero != numeroFiscal)
            {
                throw new InvalidOperationException(
                    "La solicitud fiscal no coincide con la numeración reservada.");
            }

            // No permitir reutilizar una identificación fiscal.
            bool numeroExistente = await _context.Comprobantes
                .AsNoTracking()
                .AnyAsync(
                    x => x.Id != comprobanteId
                        && x.ArcaCUITEmisor == cuitEmisor
                        && x.ArcaAmbiente == ambiente
                        && x.ArcaPuntoVenta == puntoVenta
                        && x.ArcaTipoComprobante == tipoComprobante
                        && x.ArcaNumero == numeroFiscal,
                    cancellationToken);

            if (numeroExistente)
            {
                throw new InvalidOperationException(
                    $"El número fiscal {numeroFiscal} ya está reservado.");
            }

            // Persistir la identificación fiscal antes de llamar a ARCA.
            comprobante.ArcaCUITEmisor = cuitEmisor;
            comprobante.ArcaAmbiente = ambiente;
            comprobante.ArcaPuntoVenta = puntoVenta;
            comprobante.ArcaTipoComprobante = tipoComprobante;
            comprobante.ArcaNumero = numeroFiscal;

            comprobante.ArcaSolicitudJson =
                JsonSerializer.Serialize(solicitud);

            comprobante.ArcaEstado = "EN_PROCESO";
            comprobante.ArcaUltimoError = null;

            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }


        /// <summary>
        /// Marca una solicitud fiscal como incierta sin liberar
        /// su numeración ni modificar los datos originales.
        /// </summary>
        private async Task MarcarRespuestaInciertaAsync(
            int comprobanteId,
            string motivo)
        {
            try
            {
                int actualizados = await _context.Comprobantes
                    .Where(x =>
                        x.Id == comprobanteId &&
                        x.ArcaEstado == "EN_PROCESO" &&
                        x.ArcaNumero != null &&
                        x.ArcaSolicitudJson != null)
                    .ExecuteUpdateAsync(
                        setters => setters
                            .SetProperty(
                                x => x.ArcaEstado,
                                "SIN_RESPUESTA")
                            .SetProperty(
                                x => x.ArcaUltimoError,
                                motivo),
                        CancellationToken.None);

                if (actualizados != 1)
                {
                    // Puede haber cambiado el estado por otro proceso.
                    // No sobrescribimos una autorización existente.
                    System.Diagnostics.Debug.WriteLine(
                        $"No se actualizó el estado incierto del " +
                        $"comprobante {comprobanteId}. Revisar en BD.");
                }
            }
            catch (Exception ex)
            {
                // Incluso si falla este registro, la reserva fiscal
                // ya fue confirmada antes de llamar a ARCA.
                System.Diagnostics.Debug.WriteLine(
                    $"No se pudo registrar SIN_RESPUESTA para " +
                    $"el comprobante {comprobanteId}: {ex}");
            }
        }



    }


}
