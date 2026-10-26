using ElBrezal.Application.Interfaces.ARCA;
using ElBrezal.Application.Models.ARCA;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace ElBrezal.Infrastructure.Services
{
    public class ArcaAuthService : IArcaAuthService
    {
        private readonly HttpClient _httpClient;

        public ArcaAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ArcaAuthDto> AutenticarAsync(
            string rutaCertificadoPfx,
            string password,
            string ambiente = "HOMOLOGACION",
            CancellationToken cancellationToken = default)
        {
            if (!File.Exists(rutaCertificadoPfx))
                throw new FileNotFoundException(
                    "No se encontró el certificado PFX.",
                    rutaCertificadoPfx);

            if (ambiente != "HOMOLOGACION" &&
                ambiente != "PRODUCCION")
            {
                throw new ArgumentException(
                    "El ambiente ARCA no es válido.",
                    nameof(ambiente));
            }

            using var certificado =
                X509CertificateLoader.LoadPkcs12FromFile(
                    rutaCertificadoPfx,
                    password,
                    X509KeyStorageFlags.EphemeralKeySet);

            if (!certificado.HasPrivateKey)
                throw new InvalidOperationException(
                    "El certificado no contiene una clave privada.");

            if (DateTime.UtcNow < certificado.NotBefore.ToUniversalTime() ||
                DateTime.UtcNow > certificado.NotAfter.ToUniversalTime())
            {
                throw new InvalidOperationException(
                    "El certificado no está dentro de su período de validez.");
            }

            string tra = GenerarTRA();

            string cmsFirmado = FirmarTRA(tra, certificado);

            string url = ambiente == "PRODUCCION"
                ? "https://wsaa.afip.gov.ar/ws/services/LoginCms"
                : "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";

            string respuesta = await EnviarLoginCmsAsync(
                url,
                cmsFirmado,
                cancellationToken);

            return ProcesarRespuesta(respuesta);
        }

        private static string GenerarTRA()
        {
            DateTime ahora = DateTime.UtcNow;

            var xml = new XElement(
                "loginTicketRequest",
                new XAttribute("version", "1.0"),
                new XElement("header",
                    new XElement(
                        "uniqueId",
                        DateTimeOffset.UtcNow.ToUnixTimeSeconds()),
                    new XElement(
                        "generationTime",
                        ahora.AddMinutes(-5).ToString("yyyy-MM-ddTHH:mm:ssZ")),
                    new XElement(
                        "expirationTime",
                        ahora.AddMinutes(10).ToString("yyyy-MM-ddTHH:mm:ssZ"))
                ),
                new XElement("service", "wsfe")
            );

            return xml.ToString(SaveOptions.DisableFormatting);
        }

        private static string FirmarTRA(
            string tra,
            X509Certificate2 certificado)
        {
            byte[] contenido = Encoding.UTF8.GetBytes(tra);

            var contentInfo = new ContentInfo(contenido);

            var signedCms = new SignedCms(
                contentInfo,
                detached: false);

            var signer = new CmsSigner(
                SubjectIdentifierType.IssuerAndSerialNumber,
                certificado)
            {
                IncludeOption = X509IncludeOption.EndCertOnly
            };

            signedCms.ComputeSignature(signer);

            return Convert.ToBase64String(
                signedCms.Encode());
        }

        private async Task<string> EnviarLoginCmsAsync(
            string url,
            string cmsFirmado,
            CancellationToken cancellationToken)
        {
            XNamespace soap =
                "http://schemas.xmlsoap.org/soap/envelope/";

            XNamespace wsaa =
                "http://wsaa.view.sua.dvadac.desein.afip.gov";

            var envelope = new XDocument(
                new XElement(soap + "Envelope",
                    new XElement(soap + "Body",
                        new XElement(wsaa + "loginCms",
                            new XElement(
                                wsaa + "in0",
                                cmsFirmado)
                        )
                    )
                )
            );

            using var request = new HttpRequestMessage(
                HttpMethod.Post,
                url);

            request.Content = new StringContent(
                envelope.ToString(SaveOptions.DisableFormatting),
                Encoding.UTF8,
                "text/xml");

            request.Headers.TryAddWithoutValidation(
                "SOAPAction",
                "\"\"");

            using var response = await _httpClient.SendAsync(
                request,
                cancellationToken);

            string contenido = await response.Content.ReadAsStringAsync(
                cancellationToken);

            response.EnsureSuccessStatusCode();

            return contenido;
        }

        private static ArcaAuthDto ProcesarRespuesta(
            string respuestaSoap)
        {
            XDocument soap = XDocument.Parse(respuestaSoap);

            XElement? fault = soap.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "Fault");

            if (fault != null)
                throw new InvalidOperationException(
                    $"ARCA WSAA devolvió un error: {fault.Value}");

            XElement? loginCmsReturn = soap.Descendants()
                .FirstOrDefault(
                    x => x.Name.LocalName == "loginCmsReturn");

            if (loginCmsReturn == null)
                throw new InvalidOperationException(
                    "La respuesta de WSAA no contiene loginCmsReturn.");

            XDocument ticket = XDocument.Parse(
                loginCmsReturn.Value);

            string token = ticket.Descendants()
                .First(x => x.Name.LocalName == "token").Value;

            string sign = ticket.Descendants()
                .First(x => x.Name.LocalName == "sign").Value;

            string expiration = ticket.Descendants()
                .First(x => x.Name.LocalName == "expirationTime").Value;

            return new ArcaAuthDto
            {
                Token = token,
                Sign = sign,
                ExpirationTime = DateTime.Parse(
                    expiration,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.RoundtripKind)
            };
        }
    }
}
