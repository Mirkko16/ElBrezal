using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Application.Models.ARCA;
using ElBrezal.Infrastructure.ARCA;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Infrastructure.Services
{
    public class ComprobanteAutorizacionService: IComprobanteAutorizacionService
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


        public Task<ArcaResultadoCaeDto> AutorizarAsync(int comprobanteId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException(
                "La autorización ARCA todavía no está implementada.");
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

            // IMPORTANTE:
            // Todavía falta contrastar DocTipo y DocNro con los valores
            // efectivamente enviados en la solicitud fiscal original.
            //
            // No alcanza con compararlos automáticamente contra Cliente.DNI
            // o Cliente.CUIT: la solicitud pudo utilizar otro tipo de documento.
            //
            // Hasta incorporar esa comparación, no persistimos el CAE.
            throw new InvalidOperationException(
                "ARCA devolvió un CAE, pero todavía falta verificar " +
                "el documento receptor contra la solicitud fiscal original. " +
                "No se modificó el comprobante.");
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


    }
}
