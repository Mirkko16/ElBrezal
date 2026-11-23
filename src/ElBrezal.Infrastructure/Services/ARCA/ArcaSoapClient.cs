using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace ElBrezal.Infrastructure.ARCA;

using static ArcaXmlHelper;

/// <summary>
/// Encapsula el transporte SOAP 1.1 hacia WSFEv1.
/// No interpreta respuestas fiscales ni persiste comprobantes.
/// </summary>
internal sealed class ArcaSoapClient
{
    private const string UrlHomologacion = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";
    private const string NamespaceWsfe = "http://ar.gov.afip.dif.FEV1/";
    private readonly HttpClient _httpClient;
    private readonly ArcaLogger _logger;

    public ArcaSoapClient(HttpClient httpClient, ArcaLogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }


    public async Task<string> EjecutarAsync(
        string operacion,
        XElement cuerpo,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(operacion);
        ArgumentNullException.ThrowIfNull(cuerpo);

        XNamespace soap =
            "http://schemas.xmlsoap.org/soap/envelope/";

        var envelope = new XDocument(
            new XElement(
                soap + "Envelope",
                new XElement(
                    soap + "Body",
                    cuerpo)));

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            UrlHomologacion);

        request.Content = new StringContent(
            envelope.ToString(SaveOptions.DisableFormatting),
            Encoding.UTF8,
            "text/xml");

        request.Headers.TryAddWithoutValidation(
            "SOAPAction",
            $"\"{NamespaceWsfe}{operacion}\"");

        var reloj = Stopwatch.StartNew();

        try
        {
            // Enviar solicitud SOAP.
            using var response = await _httpClient.SendAsync(
                request,
                cancellationToken);

            // Leer respuesta completa.
            string contenido = await response.Content
                .ReadAsStringAsync(cancellationToken);

            reloj.Stop();

            await _logger.EscribirAsync(
                "INFO",
                operacion,
                $"HTTP={(int)response.StatusCode}, " +
                $"Duración={reloj.ElapsedMilliseconds}ms");

            // Detectar errores HTTP.
            if (!response.IsSuccessStatusCode)
            {
                string mensajeSoap = ObtenerErrorSoap(contenido);

                throw new HttpRequestException(
                    $"WSFEv1 respondió HTTP " +
                    $"{(int)response.StatusCode}. {mensajeSoap}",
                    null,
                    response.StatusCode);
            }

            // Validar que la respuesta sea XML.
            XDocument documento;

            try
            {
                documento = XDocument.Parse(contenido);
            }
            catch (System.Xml.XmlException ex)
            {
                throw new InvalidOperationException(
                    "ARCA devolvió una respuesta que no contiene " +
                    "un documento XML válido.",
                    ex);
            }

            // Detectar SOAP Fault.
            var fault = documento.Descendants()
                .FirstOrDefault(x =>
                    x.Name.LocalName == "Fault");

            if (fault != null)
            {
                throw new InvalidOperationException(
                    $"ARCA devolvió un SOAP Fault: " +
                    ObtenerErrorSoap(contenido));
            }

            return contenido;
        }
        catch (OperationCanceledException ex)
            when (!cancellationToken.IsCancellationRequested)
        {
            reloj.Stop();

            await _logger.EscribirAsync(
                "ERROR",
                operacion,
                $"Timeout después de " +
                $"{reloj.ElapsedMilliseconds}ms. " +
                "La operación fiscal requiere conciliación.");

            throw new TimeoutException(
                "Se agotó el tiempo de espera de ARCA. " +
                "No se puede determinar si el comprobante " +
                "fue autorizado. Debe consultarse su estado " +
                "antes de intentar nuevamente.",
                ex);
        }
        catch (OperationCanceledException)
            when (cancellationToken.IsCancellationRequested)
        {
            reloj.Stop();

            await _logger.EscribirAsync(
                "WARN",
                operacion,
                "La operación SOAP fue cancelada. " +
                "Si se había enviado una solicitud fiscal, " +
                "puede requerir conciliación.");

            throw;
        }
        catch (Exception ex)
        {
            reloj.Stop();

            await _logger.EscribirAsync(
                "ERROR",
                operacion,
                $"{ex.GetType().Name}: {ex.Message}. " +
                $"Duración={reloj.ElapsedMilliseconds}ms");

            throw;
        }
    }


}
