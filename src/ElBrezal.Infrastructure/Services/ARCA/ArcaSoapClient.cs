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

    /// <summary>
    /// Envía una operación SOAP a homologación y devuelve el XML de respuesta.
    /// Conserva por ahora la restricción de ambiente del servicio original.
    /// </summary>
    public async Task<string> EjecutarAsync(
        string operacion, XElement cuerpo, CancellationToken cancellationToken)
    {
        XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
        var envelope = new XDocument(
            new XElement(soap + "Envelope", new XElement(soap + "Body", cuerpo)));

        using var request = new HttpRequestMessage(HttpMethod.Post, UrlHomologacion);
        request.Content = new StringContent(
            envelope.ToString(SaveOptions.DisableFormatting), Encoding.UTF8, "text/xml");
        request.Headers.TryAddWithoutValidation(
            "SOAPAction", $"\"{NamespaceWsfe}{operacion}\"");

        var reloj = Stopwatch.StartNew();
        try
        {
            using var response = await _httpClient.SendAsync(request, cancellationToken);
            string contenido = await response.Content.ReadAsStringAsync(cancellationToken);
            reloj.Stop();

            await _logger.EscribirAsync("INFO", operacion,
                $"HTTP={(int)response.StatusCode}, Duración={reloj.ElapsedMilliseconds}ms");

            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException(
                    $"WSFEv1 respondió HTTP {(int)response.StatusCode}. {ObtenerErrorSoap(contenido)}");

            var documento = XDocument.Parse(contenido);
            if (documento.Descendants().Any(x => x.Name.LocalName == "Fault"))
                throw new InvalidOperationException(ObtenerErrorSoap(contenido));

            return contenido;
        }
        catch (Exception ex)
        {
            await _logger.EscribirAsync("ERROR", operacion,
                $"{ex.GetType().Name}: {ex.Message}");
            throw;
        }
    }

}
