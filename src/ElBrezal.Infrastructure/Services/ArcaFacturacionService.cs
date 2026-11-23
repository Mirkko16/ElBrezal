using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Infrastructure.ARCA;
using static ElBrezal.Infrastructure.ARCA.ArcaXmlHelper;
using ElBrezal.Application.Models.ARCA;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace ElBrezal.Infrastructure.Services
{
    public class ArcaFacturacionService : IArcaFacturacionService
    {

        private const string NamespaceWsfe =
            "http://ar.gov.afip.dif.FEV1/";

        private readonly ArcaLogger _logger;
        private readonly ArcaSoapClient _soapClient;

        public ArcaFacturacionService(HttpClient httpClient)
        {
            _logger = new ArcaLogger();
            _soapClient = new ArcaSoapClient(httpClient, _logger);
        }

        /// <summary>Consulta los puntos de venta habilitados para el CUIT emisor en homologación.</summary>
        public async Task<ArcaPuntosVentaResultadoDto> ObtenerPuntosVentaAsync(
            ArcaAuthDto auth, long cuitEmisor, string ambiente,
            CancellationToken cancellationToken = default)
        {
            ValidarCredencialesArca(auth, cuitEmisor, ambiente);
            const string operacion = "FEParamGetPtosVenta";
            XNamespace wsfe = NamespaceWsfe;
            var cuerpo = new XElement(wsfe + operacion, CrearAuthSoap(auth, cuitEmisor));
            await EscribirLogAsync("INFO", operacion, $"Consultando puntos de venta. Ambiente={ambiente}, CUIT={cuitEmisor}");
            string xml = await EjecutarOperacionSoapAsync(operacion, cuerpo, cancellationToken);
            var respuesta = ProcesarRespuestaPuntosVenta(xml);
            await EscribirLogAsync("INFO", operacion, $"Puntos de venta={respuesta.PuntosVenta.Count}");
            foreach (var punto in respuesta.PuntosVenta)
                await EscribirLogAsync("INFO", operacion,
                    $"PuntoVenta={punto.Numero}, EmisionTipo={punto.TipoEmision}, Bloqueado={punto.Bloqueado}, FechaBaja={punto.FechaBaja ?? "-"}");
            foreach (var observacion in respuesta.Observaciones)
                await EscribirLogAsync("WARNING", operacion, observacion);
            return respuesta;
        }


        /// <summary>Consulta FEDummy para comprobar el estado de los servidores de WSFEv1.</summary>
        public async Task<string> ConsultarEstadoServicioAsync(CancellationToken cancellationToken = default)
        {
            const string operacion = "FEDummy";
            XNamespace wsfe = NamespaceWsfe;
            await EscribirLogAsync("INFO", operacion, "Consultando estado de WSFEv1 en homologación.");
            string xml = await EjecutarOperacionSoapAsync(
                operacion, new XElement(wsfe + operacion), cancellationToken);
            var documento = XDocument.Parse(xml);
            var resultado = documento.Descendants().FirstOrDefault(x => x.Name.LocalName == "FEDummyResult")
                ?? throw new InvalidOperationException("La respuesta no contiene FEDummyResult.");
            string mensaje = $"AppServer: {ObtenerValor(resultado, "AppServer") ?? "SIN DATOS"}\n" +
                $"DbServer: {ObtenerValor(resultado, "DbServer") ?? "SIN DATOS"}\n" +
                $"AuthServer: {ObtenerValor(resultado, "AuthServer") ?? "SIN DATOS"}";
            await EscribirLogAsync("INFO", operacion, mensaje.Replace("\n", " | "));
            return mensaje;
        }


        private static ArcaPuntosVentaResultadoDto
            ProcesarRespuestaPuntosVenta(string xmlRespuesta)
        {
            var documento = XDocument.Parse(xmlRespuesta);

            var fault = documento.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "Fault");

            if (fault != null)
            {
                throw new InvalidOperationException(
                    $"Error SOAP de WSFEv1: {ObtenerErrorSoap(xmlRespuesta)}");
            }

            var resultado = documento.Descendants()
                .FirstOrDefault(
                    x => x.Name.LocalName == "FEParamGetPtosVentaResult");

            if (resultado == null)
            {
                throw new InvalidOperationException(
                    "WSFEv1 no devolvió FEParamGetPtosVentaResult.");
            }

            var respuesta = new ArcaPuntosVentaResultadoDto();

            var errores = resultado.Descendants()
                .Where(x => x.Name.LocalName == "Errors")
                .Elements()
                .Where(x => x.Name.LocalName == "Err")
                .Select(x => new
                {
                    Codigo = ObtenerValor(x, "Code") ?? "",
                    Mensaje = ObtenerValor(x, "Msg") ?? ""
                })
                .ToList();

            foreach (var error in errores)
            {
                respuesta.Observaciones.Add(
                    $"ARCA [{error.Codigo}] {error.Mensaje}");
            }

            var erroresBloqueantes = errores
                .Where(x => x.Codigo != "602")
                .ToList();

            if (erroresBloqueantes.Count > 0)
            {
                throw new InvalidOperationException(
                    "WSFEv1 devolvió errores:\n" +
                    string.Join(
                        "\n",
                        erroresBloqueantes.Select(x =>
                            $"[{x.Codigo}] {x.Mensaje}")));
            }

            respuesta.PuntosVenta = resultado.Descendants()
                .Where(x => x.Name.LocalName == "PtoVenta")
                .Select(x => new ArcaPuntoVentaDto
                {
                    Numero = int.Parse(
                        ObtenerValor(x, "Nro") ?? "0",
                        CultureInfo.InvariantCulture),

                    TipoEmision =
                        ObtenerValor(x, "EmisionTipo") ?? string.Empty,

                    Bloqueado =
                        ObtenerValor(x, "Bloqueado") ?? string.Empty,

                    FechaBaja =
                        ObtenerValor(x, "FchBaja")
                })
                .ToList();

            var eventos = resultado.Descendants()
                .Where(x => x.Name.LocalName == "Events")
                .Elements()
                .Where(x => x.Name.LocalName == "Evt")
                .Select(FormatearMensaje)
                .ToList();

            respuesta.Observaciones.AddRange(eventos);

            return respuesta;
        }







        /// <summary>Registra eventos técnicos sin incluir credenciales WSAA.</summary>
        private Task EscribirLogAsync(string nivel, string operacion, string mensaje)
            => _logger.EscribirAsync(nivel, operacion, mensaje);



        /// <summary>Consulta los tipos de comprobante disponibles en WSFEv1.</summary>
        public async Task<ArcaTiposComprobanteResultadoDto> ObtenerTiposComprobanteAsync(
            ArcaAuthDto auth, long cuitEmisor, string ambiente,
            CancellationToken cancellationToken = default)
        {
            ValidarCredencialesArca(auth, cuitEmisor, ambiente);
            const string operacion = "FEParamGetTiposCbte";
            XNamespace wsfe = NamespaceWsfe;
            var cuerpo = new XElement(wsfe + operacion, CrearAuthSoap(auth, cuitEmisor));
            await EscribirLogAsync("INFO", operacion, $"Consultando tipos. Ambiente={ambiente}, CUIT={cuitEmisor}");
            string xml = await EjecutarOperacionSoapAsync(operacion, cuerpo, cancellationToken);
            var respuesta = ProcesarRespuestaTiposComprobante(xml);
            await EscribirLogAsync("INFO", operacion, $"Tipos encontrados={respuesta.TiposComprobante.Count}");
            foreach (var tipo in respuesta.TiposComprobante)
                await EscribirLogAsync("INFO", operacion,
                    $"Id={tipo.Id}, Descripción={tipo.Descripcion}, Desde={tipo.FechaDesde ?? "-"}, Hasta={tipo.FechaHasta ?? "-"}");
            foreach (var observacion in respuesta.Observaciones)
                await EscribirLogAsync("WARNING", operacion, observacion);
            return respuesta;
        }


        private static ArcaTiposComprobanteResultadoDto
            ProcesarRespuestaTiposComprobante(string xmlRespuesta)
        {
            var documento = XDocument.Parse(xmlRespuesta);

            var fault = documento.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "Fault");

            if (fault != null)
            {
                throw new InvalidOperationException(
                    "WSFEv1 devolvió un error SOAP: " +
                    ObtenerErrorSoap(xmlRespuesta));
            }

            var resultado = documento.Descendants()
                .FirstOrDefault(
                    x => x.Name.LocalName == "FEParamGetTiposCbteResult");

            if (resultado == null)
            {
                throw new InvalidOperationException(
                    "La respuesta no contiene FEParamGetTiposCbteResult.");
            }

            var respuesta = new ArcaTiposComprobanteResultadoDto();

            var errores = resultado.Descendants()
                .Where(x => x.Name.LocalName == "Errors")
                .Elements()
                .Where(x => x.Name.LocalName == "Err")
                .Select(x =>
                    $"[{ObtenerValor(x, "Code")}] " +
                    ObtenerValor(x, "Msg"))
                .ToList();

            if (errores.Count > 0)
            {
                throw new InvalidOperationException(
                    "WSFEv1 devolvió errores:\n" +
                    string.Join("\n", errores));
            }

            // La estructura de WSFEv1 contiene:
            // ResultGet / CbteTipo / Id, Desc, FchDesde, FchHasta

            respuesta.TiposComprobante = resultado.Descendants()
                .Where(x => x.Name.LocalName == "CbteTipo")
                .Select(x => new ArcaTipoComprobanteDto
                {
                    Id = int.Parse(
                        ObtenerValor(x, "Id") ?? "0",
                        CultureInfo.InvariantCulture),

                    Descripcion = ObtenerValor(x, "Desc") ?? "",

                    FechaDesde = ObtenerValor(x, "FchDesde"),

                    FechaHasta = ObtenerValor(x, "FchHasta")
                })
                .ToList();

            var eventos = resultado.Descendants()
                .Where(x => x.Name.LocalName == "Events")
                .Elements()
                .Where(x => x.Name.LocalName == "Evt")
                .Select(FormatearMensaje)
                .ToList();

            respuesta.Observaciones.AddRange(eventos);

            return respuesta;
        }


        /// <summary>Obtiene el último número autorizado para un punto de venta y tipo fiscal.</summary>
        public async Task<ArcaUltimoComprobanteDto> ObtenerUltimoComprobanteAutorizadoAsync(
            ArcaAuthDto auth, long cuitEmisor, string ambiente,
            int puntoVenta, int tipoComprobante, CancellationToken cancellationToken = default)
        {
            ValidarCredencialesArca(auth, cuitEmisor, ambiente);
            if (puntoVenta <= 0 || tipoComprobante <= 0)
                throw new ArgumentException("El punto de venta y tipo de comprobante deben ser válidos.");
            const string operacion = "FECompUltimoAutorizado";
            XNamespace wsfe = NamespaceWsfe;
            var cuerpo = new XElement(wsfe + operacion,
                CrearAuthSoap(auth, cuitEmisor),
                new XElement(wsfe + "PtoVta", puntoVenta),
                new XElement(wsfe + "CbteTipo", tipoComprobante));
            await EscribirLogAsync("INFO", operacion,
                $"Consultando último número. Ambiente={ambiente}, CUIT={cuitEmisor}, PV={puntoVenta}, Tipo={tipoComprobante}");
            string xml = await EjecutarOperacionSoapAsync(operacion, cuerpo, cancellationToken);
            var respuesta = ProcesarRespuestaUltimoComprobante(xml);

            if (respuesta.PuntoVenta != puntoVenta ||
                respuesta.TipoComprobante != tipoComprobante ||
                respuesta.UltimoNumero < 0)
            {
                throw new InvalidOperationException(
                    "ARCA devolvió una numeración inconsistente " +
                    "con el punto de venta o tipo solicitado.");
            }
            await EscribirLogAsync("INFO", operacion,
                $"Último autorizado={respuesta.UltimoNumero}, PV={respuesta.PuntoVenta}, Tipo={respuesta.TipoComprobante}");
            return respuesta;
        }


        private static ArcaUltimoComprobanteDto
            ProcesarRespuestaUltimoComprobante(string xmlRespuesta)
        {
            var documento = XDocument.Parse(xmlRespuesta);

            var fault = documento.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "Fault");

            if (fault != null)
            {
                throw new InvalidOperationException(
                    "WSFEv1 devolvió un error SOAP: " +
                    ObtenerErrorSoap(xmlRespuesta));
            }

            var resultado = documento.Descendants()
                .FirstOrDefault(
                    x => x.Name.LocalName == "FECompUltimoAutorizadoResult");

            if (resultado == null)
            {
                throw new InvalidOperationException(
                    "La respuesta no contiene FECompUltimoAutorizadoResult.");
            }

            var errores = resultado.Descendants()
                .Where(x => x.Name.LocalName == "Errors")
                .Elements()
                .Where(x => x.Name.LocalName == "Err")
                .Select(x =>
                    $"[{ObtenerValor(x, "Code")}] " +
                    ObtenerValor(x, "Msg"))
                .ToList();

            if (errores.Count > 0)
            {
                throw new InvalidOperationException(
                    "WSFEv1 devolvió errores:\n" +
                    string.Join("\n", errores));
            }

            string? puntoVenta = ObtenerValor(resultado, "PtoVta");
            string? tipoComprobante = ObtenerValor(resultado, "CbteTipo");
            string? ultimoNumero = ObtenerValor(resultado, "CbteNro");

            if (!int.TryParse(puntoVenta, out int ptoVta) ||
                !int.TryParse(tipoComprobante, out int cbteTipo) ||
                !long.TryParse(ultimoNumero, out long cbteNro))
            {
                throw new InvalidOperationException(
                    "La respuesta de ARCA no contiene una numeración válida.");
            }

            return new ArcaUltimoComprobanteDto
            {
                PuntoVenta = ptoVta,
                TipoComprobante = cbteTipo,
                UltimoNumero = cbteNro
            };
        }

        /// <summary>Solicita a WSFEv1 la autorización fiscal de un comprobante; no persiste el resultado.</summary>

        public async Task<ArcaResultadoCaeDto> SolicitarCaeAsync(
            ArcaAuthDto auth,
            long cuitEmisor,
            string ambiente,
            ArcaSolicitudCaeDto solicitud,
            CancellationToken cancellationToken = default)
        {
            const string operacion = "FECAESolicitar";

            ValidarCredencialesArca(auth, cuitEmisor, ambiente);
            ArgumentNullException.ThrowIfNull(solicitud);

            // 1. Validar identificación fiscal.
            if (solicitud.PuntoVenta <= 0 ||
                solicitud.TipoComprobante <= 0 ||
                solicitud.Numero <= 0)
            {
                throw new ArgumentException(
                    "La identificación fiscal del comprobante no es válida.");
            }

            // 2. Por ahora solamente admitimos productos.
            if (solicitud.Concepto != 1)
            {
                throw new NotSupportedException(
                    "Esta primera implementación admite solamente productos.");
            }

            // 3. Validar datos fiscales obligatorios.
            if (solicitud.ImporteTotal <= 0 ||
                solicitud.DocTipo <= 0 ||
                solicitud.DocNro < 0 ||
                solicitud.CondicionIvaReceptorId <= 0)
            {
                throw new ArgumentException(
                    "Los datos fiscales de la solicitud están incompletos.");
            }

            // 4. Validar identificación del receptor.
            if (solicitud.DocTipo == 99 && solicitud.DocNro != 0)
            {
                throw new ArgumentException(
                    "Un Consumidor Final sin identificar debe tener " +
                    "número de documento cero.");
            }

            if (solicitud.DocTipo != 99 && solicitud.DocNro <= 0)
            {
                throw new ArgumentException(
                    "El documento del receptor debe ser mayor a cero.");
            }

            // 5. Validar importes negativos.
            if (solicitud.ImporteNeto < 0 ||
                solicitud.ImporteNoGravado < 0 ||
                solicitud.ImporteExento < 0 ||
                solicitud.ImporteIVA < 0 ||
                solicitud.ImporteTributos < 0)
            {
                throw new ArgumentException(
                    "Los importes fiscales no pueden ser negativos.");
            }

            // 6. Validar que los importes fiscales coincidan.
            decimal totalCalculado =
                solicitud.ImporteNeto +
                solicitud.ImporteNoGravado +
                solicitud.ImporteExento +
                solicitud.ImporteIVA +
                solicitud.ImporteTributos;

            if (totalCalculado != solicitud.ImporteTotal)
            {
                throw new ArgumentException(
                    "El importe total no coincide con sus componentes fiscales.");
            }

            // 7. Validar el detalle de alícuotas.
            if (solicitud.AlicuotasIVA is null)
            {
                throw new ArgumentException(
                    "No se informó el detalle de alícuotas de IVA.");
            }

            if (solicitud.AlicuotasIVA.Any(x =>
                x.Id <= 0 ||
                x.BaseImponible < 0 ||
                x.Importe < 0))
            {
                throw new ArgumentException(
                    "Existen alícuotas de IVA con valores inválidos.");
            }

            decimal netoAlicuotas =
                solicitud.AlicuotasIVA.Sum(x => x.BaseImponible);

            decimal ivaAlicuotas =
                solicitud.AlicuotasIVA.Sum(x => x.Importe);

            if (netoAlicuotas != solicitud.ImporteNeto ||
                ivaAlicuotas != solicitud.ImporteIVA)
            {
                throw new ArgumentException(
                    "El desglose de alícuotas no coincide " +
                    "con los importes fiscales del comprobante.");
            }

            // 8. Construir el detalle fiscal SOAP.
            XNamespace wsfe = NamespaceWsfe;

            var detalle = new XElement(
                wsfe + "FECAEDetRequest",

                new XElement(
                    wsfe + "Concepto",
                    solicitud.Concepto),

                new XElement(
                    wsfe + "DocTipo",
                    solicitud.DocTipo),

                new XElement(
                    wsfe + "DocNro",
                    solicitud.DocNro),

                new XElement(
                    wsfe + "CbteDesde",
                    solicitud.Numero),

                new XElement(
                    wsfe + "CbteHasta",
                    solicitud.Numero),

                new XElement(
                    wsfe + "CbteFch",
                    solicitud.Fecha.ToString("yyyyMMdd")),

                new XElement(
                    wsfe + "ImpTotal",
                    FormatearImporteArca(solicitud.ImporteTotal)),

                new XElement(
                    wsfe + "ImpTotConc",
                    FormatearImporteArca(solicitud.ImporteNoGravado)),

                new XElement(
                    wsfe + "ImpNeto",
                    FormatearImporteArca(solicitud.ImporteNeto)),

                new XElement(
                    wsfe + "ImpOpEx",
                    FormatearImporteArca(solicitud.ImporteExento)),

                new XElement(
                    wsfe + "ImpTrib",
                    FormatearImporteArca(solicitud.ImporteTributos)),

                new XElement(
                    wsfe + "ImpIVA",
                    FormatearImporteArca(solicitud.ImporteIVA)),

                new XElement(
                    wsfe + "MonId",
                    "PES"),

                new XElement(
                    wsfe + "MonCotiz",
                    "1"),

                new XElement(
                    wsfe + "CondicionIVAReceptorId",
                    solicitud.CondicionIvaReceptorId)
            );

            // 9. Incorporar las alícuotas de IVA.
            if (solicitud.AlicuotasIVA.Count > 0)
            {
                detalle.Add(
                    new XElement(
                        wsfe + "Iva",

                        solicitud.AlicuotasIVA.Select(x =>
                            new XElement(
                                wsfe + "AlicIva",

                                new XElement(
                                    wsfe + "Id",
                                    x.Id),

                                new XElement(
                                    wsfe + "BaseImp",
                                    FormatearImporteArca(x.BaseImponible)),

                                new XElement(
                                    wsfe + "Importe",
                                    FormatearImporteArca(x.Importe))
                            )
                        )
                    )
                );
            }

            // 10. Construir la solicitud FECAESolicitar.
            var cuerpo = new XElement(
                wsfe + operacion,

                CrearAuthSoap(auth, cuitEmisor),

                new XElement(
                    wsfe + "FeCAEReq",

                    new XElement(
                        wsfe + "FeCabReq",

                        new XElement(
                            wsfe + "CantReg",
                            1),

                        new XElement(
                            wsfe + "PtoVta",
                            solicitud.PuntoVenta),

                        new XElement(
                            wsfe + "CbteTipo",
                            solicitud.TipoComprobante)
                    ),

                    new XElement(
                        wsfe + "FeDetReq",
                        detalle)
                )
            );

            // 11. Registrar el intento de autorización.
            await EscribirLogAsync(
                "INFO",
                operacion,
                $"Solicitando CAE. CUIT={cuitEmisor}, " +
                $"PV={solicitud.PuntoVenta}, " +
                $"Tipo={solicitud.TipoComprobante}, " +
                $"Numero={solicitud.Numero}");

            // 12. Ejecutar la operación SOAP.
            string xml = await EjecutarOperacionSoapAsync(
                operacion,
                cuerpo,
                cancellationToken);

            // 13. Interpretar la respuesta.
            var documento = XDocument.Parse(xml);

            var resultado = documento.Descendants()
                .FirstOrDefault(x =>
                    x.Name.LocalName == "FECAESolicitarResult")
                ?? throw new InvalidOperationException(
                    "ARCA no devolvió FECAESolicitarResult.");

            var respuesta = new ArcaResultadoCaeDto
            {
                PuntoVenta = solicitud.PuntoVenta,
                TipoComprobante = solicitud.TipoComprobante,
                Numero = solicitud.Numero,
                Resultado = "SIN_RESPUESTA"
            };

            // 14. Recuperar errores generales.
            respuesta.Errores.AddRange(
                ObtenerMensajesArca(
                    resultado,
                    "Errors",
                    "Err"));

            var cabecera = resultado.Descendants()
                .FirstOrDefault(x =>
                    x.Name.LocalName == "FeCabResp");

            var detalleRespuesta = resultado.Descendants()
                .FirstOrDefault(x =>
                    x.Name.LocalName == "FECAEDetResponse");


            if (detalleRespuesta != null && cabecera is null)
            {
                throw new InvalidOperationException(
                    "ARCA devolvió un detalle fiscal sin cabecera. " +
                    "El comprobante requiere conciliación.");
            }

            // 15. Validar la identidad fiscal de la respuesta.
            // No se debe registrar un CAE si ARCA responde
            // con otro punto de venta, tipo o número.
            if (cabecera != null)
            {
                string? puntoVentaRespuesta =
                    ObtenerValor(cabecera, "PtoVta");

                string? tipoComprobanteRespuesta =
                    ObtenerValor(cabecera, "CbteTipo");

                if (!int.TryParse(
                        puntoVentaRespuesta,
                        out int puntoVentaArca) ||
                    !int.TryParse(
                        tipoComprobanteRespuesta,
                        out int tipoArca) ||
                    puntoVentaArca != solicitud.PuntoVenta ||
                    tipoArca != solicitud.TipoComprobante)
                {
                    throw new InvalidOperationException(
                        "La cabecera de respuesta de ARCA no coincide " +
                        "con la identificación fiscal solicitada.");
                }
            }

            if (detalleRespuesta != null)
            {
                string? numeroDesdeRespuesta =
                    ObtenerValor(detalleRespuesta, "CbteDesde");

                string? numeroHastaRespuesta =
                    ObtenerValor(detalleRespuesta, "CbteHasta");

                if (!long.TryParse(
                        numeroDesdeRespuesta,
                        out long numeroDesdeArca) ||
                    !long.TryParse(
                        numeroHastaRespuesta,
                        out long numeroHastaArca) ||
                    numeroDesdeArca != solicitud.Numero ||
                    numeroHastaArca != solicitud.Numero)
                {
                    throw new InvalidOperationException(
                        "La numeración devuelta por ARCA no coincide " +
                        "con el comprobante solicitado.");
                }

                // 16. Recuperar el resultado fiscal.
                respuesta.Resultado =
                    ObtenerValor(detalleRespuesta, "Resultado")
                    ?? "SIN_RESPUESTA";

                respuesta.CAE =
                    ObtenerValor(detalleRespuesta, "CAE");

                respuesta.CAEVencimiento =
                    ParsearFechaArca(
                        ObtenerValor(
                            detalleRespuesta,
                            "CAEFchVto"));

                respuesta.Observaciones.AddRange(
                    ObtenerMensajesArca(
                        detalleRespuesta,
                        "Observaciones",
                        "Obs"));
            }

            // Si no existe detalle, no asumimos rechazo.
            // Se conserva SIN_RESPUESTA para conciliación.

            // 17. Registrar resultado.
            await EscribirLogAsync(
                "INFO",
                operacion,
                $"Resultado={respuesta.Resultado}, " +
                $"Autorizado={respuesta.Aprobado}, " +
                $"Numero={respuesta.Numero}");

            return respuesta;
        }


        /// <summary>
        /// Consulta un comprobante fiscal en ARCA mediante FECompConsultar.
        /// Recupera el CAE y los datos fiscales necesarios para verificar
        /// su correspondencia con el comprobante registrado localmente.
        /// </summary>
        /// <param name="auth">Credenciales WSAA vigentes.</param>
        /// <param name="cuitEmisor">CUIT del emisor fiscal.</param>
        /// <param name="ambiente">Ambiente ARCA.</param>
        /// <param name="puntoVenta">Punto de venta fiscal.</param>
        /// <param name="tipoComprobante">Código de comprobante ARCA.</param>
        /// <param name="numero">Número fiscal del comprobante.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>
        /// Datos del comprobante consultado o null cuando ARCA
        /// confirma que no existe.
        /// </returns>

        public async Task<ArcaResultadoCaeDto?> ConsultarComprobanteAsync(
            ArcaAuthDto auth,
            long cuitEmisor,
            string ambiente,
            int puntoVenta,
            int tipoComprobante,
            long numero,
            CancellationToken cancellationToken = default)
        {
            const string operacion = "FECompConsultar";

            ValidarCredencialesArca(auth, cuitEmisor, ambiente);

            if (puntoVenta <= 0 || tipoComprobante <= 0 || numero <= 0)
            {
                throw new ArgumentException(
                    "La identificación del comprobante no es válida.");
            }

            XNamespace wsfe = NamespaceWsfe;

            var cuerpo = new XElement(
                wsfe + operacion,
                CrearAuthSoap(auth, cuitEmisor),
                new XElement(
                    wsfe + "FeCompConsReq",
                    new XElement(wsfe + "CbteTipo", tipoComprobante),
                    new XElement(wsfe + "CbteNro", numero),
                    new XElement(wsfe + "PtoVta", puntoVenta)
                )
            );

            await EscribirLogAsync(
                "INFO",
                operacion,
                $"Consultando CUIT={cuitEmisor}, PV={puntoVenta}, " +
                $"Tipo={tipoComprobante}, Numero={numero}");

            string xml = await EjecutarOperacionSoapAsync(
                operacion,
                cuerpo,
                cancellationToken);

            var documento = XDocument.Parse(xml);

            var resultado = documento.Descendants()
                .FirstOrDefault(x =>
                    x.Name.LocalName == "FECompConsultarResult")
                ?? throw new InvalidOperationException(
                    "ARCA no devolvió FECompConsultarResult.");

            var errores = ObtenerMensajesArca(
                resultado,
                "Errors",
                "Err");

            var datos = resultado.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "ResultGet");

            if (datos == null)
            {
                var erroresXml = resultado.Descendants()
                    .Where(x => x.Name.LocalName == "Err")
                    .ToList();

                bool noEncontrado =
                    erroresXml.Count > 0 &&
                    erroresXml.All(x =>
                        ObtenerValor(x, "Code") == "602");

                if (noEncontrado)
                {
                    await EscribirLogAsync(
                        "INFO",
                        operacion,
                        $"Comprobante no encontrado: {numero}");

                    return null;
                }

                throw new InvalidOperationException(
                    "ARCA no devolvió el comprobante consultado. " +
                    string.Join(" | ", errores));
            }

            // ============================================================
            // IDENTIFICACIÓN FISCAL
            //
            // FECompConsultar utiliza CbteDesde y CbteHasta
            // en la respuesta, no CbteNro.
            // ============================================================

            if (!int.TryParse(
                    ObtenerValor(datos, "PtoVta"),
                    out int puntoVentaRespuesta) ||
                !int.TryParse(
                    ObtenerValor(datos, "CbteTipo"),
                    out int tipoRespuesta) ||
                !long.TryParse(
                    ObtenerValor(datos, "CbteDesde"),
                    out long numeroDesde) ||
                !long.TryParse(
                    ObtenerValor(datos, "CbteHasta"),
                    out long numeroHasta))
            {
                throw new InvalidOperationException(
                    "ARCA devolvió una identificación fiscal incompleta.");
            }

            // La consulta corresponde a un comprobante individual.
            if (numeroDesde != numeroHasta)
            {
                throw new InvalidOperationException(
                    "ARCA devolvió un rango de comprobantes inesperado.");
            }

            if (puntoVentaRespuesta != puntoVenta ||
                tipoRespuesta != tipoComprobante ||
                numeroDesde != numero)
            {
                throw new InvalidOperationException(
                    "La identificación fiscal devuelta por ARCA " +
                    "no coincide con la consulta realizada.");
            }

            // ============================================================
            // AUTORIZACIÓN
            // ============================================================

            string resultadoArca =
                ObtenerValor(datos, "Resultado")?.Trim()
                ?? string.Empty;

            string? codigoAutorizacion =
                ObtenerValor(datos, "CodAutorizacion");

            string? tipoEmision =
                ObtenerValor(datos, "EmisionTipo");

            DateOnly? fechaComprobante = ParsearFechaArca(
                ObtenerValor(datos, "CbteFch"));

            DateOnly? vencimiento = ParsearFechaArca(
                ObtenerValor(datos, "FchVto"));

            // ============================================================
            // DOCUMENTO DEL RECEPTOR
            // ============================================================

            int? tipoDocumento =
                int.TryParse(
                    ObtenerValor(datos, "DocTipo"),
                    out int docTipo)
                        ? docTipo
                        : null;

            long? numeroDocumento =
                long.TryParse(
                    ObtenerValor(datos, "DocNro"),
                    out long docNro)
                        ? docNro
                        : null;

            // ============================================================
            // IMPORTE TOTAL
            // ============================================================

            decimal? importeTotal =
                decimal.TryParse(
                    ObtenerValor(datos, "ImpTotal"),
                    System.Globalization.NumberStyles.Number,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal importe)
                        ? importe
                        : null;

            // ============================================================
            // CONSTRUIR RESPUESTA
            // ============================================================

            var respuesta = new ArcaResultadoCaeDto
            {
                PuntoVenta = puntoVentaRespuesta,
                TipoComprobante = tipoRespuesta,
                Numero = numeroDesde,

                Resultado = resultadoArca,

                CAE = codigoAutorizacion,
                CAEVencimiento = vencimiento,
                TipoEmision = tipoEmision,

                FechaComprobante = fechaComprobante,
                TipoDocumentoReceptor = tipoDocumento,
                NumeroDocumentoReceptor = numeroDocumento,
                ImporteTotal = importeTotal
            };

            respuesta.Errores.AddRange(errores);

            // Recuperar observaciones si ARCA las informa.
            var observaciones = datos
                .Descendants()
                .Where(x => x.Name.LocalName == "Obs")
                .Select(x =>
                {
                    string codigo =
                        ObtenerValor(x, "Code") ?? string.Empty;

                    string mensaje =
                        ObtenerValor(x, "Msg") ?? string.Empty;

                    return $"{codigo}: {mensaje}".Trim();
                })
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            respuesta.Observaciones.AddRange(observaciones);

            await EscribirLogAsync(
                "INFO",
                operacion,
                $"Consulta finalizada. Numero={numeroDesde}, " +
                $"Resultado={respuesta.Resultado}, " +
                $"Autorizado={respuesta.Aprobado}");

            return respuesta;
        }



        private static void ValidarCredencialesArca(
    ArcaAuthDto auth,
    long cuitEmisor,
    string ambiente)
        {
            ArgumentNullException.ThrowIfNull(auth);

            if (string.IsNullOrWhiteSpace(auth.Token) ||
                string.IsNullOrWhiteSpace(auth.Sign))
            {
                throw new ArgumentException(
                    "Las credenciales de ARCA están incompletas.");
            }

            if (cuitEmisor <= 0)
                throw new ArgumentException("El CUIT emisor no es válido.");

            if (ambiente != "HOMOLOGACION")
                throw new InvalidOperationException(
                    "Por ahora solamente se permite homologación.");
        }

        private static XElement CrearAuthSoap(
            ArcaAuthDto auth,
            long cuitEmisor)
        {
            XNamespace wsfe = NamespaceWsfe;

            return new XElement(wsfe + "Auth",
                new XElement(wsfe + "Token", auth.Token),
                new XElement(wsfe + "Sign", auth.Sign),
                new XElement(wsfe + "Cuit", cuitEmisor)
            );
        }

        /// <summary>Envía una operación SOAP mediante el cliente de transporte compartido.</summary>
        private Task<string> EjecutarOperacionSoapAsync(
            string operacion, XElement cuerpo, CancellationToken cancellationToken)
            => _soapClient.EjecutarAsync(operacion, cuerpo, cancellationToken);


    }
}