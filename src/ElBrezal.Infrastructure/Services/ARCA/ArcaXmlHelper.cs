using System.Globalization;
using System.Xml.Linq;

namespace ElBrezal.Infrastructure.ARCA;

/// <summary>
/// Utilidades de interpretación de respuestas XML de WSFEv1.
/// No realiza llamadas HTTP ni modifica la base de datos.
/// </summary>
internal static class ArcaXmlHelper
{
    internal static string? ObtenerValor(
        XElement elemento,
        string nombre)
    {
        return elemento.Elements()
            .FirstOrDefault(x => x.Name.LocalName == nombre)
            ?.Value;
    }

    internal static string FormatearMensaje(XElement elemento)
    {
        string codigo = ObtenerValor(elemento, "Code") ?? "";
        string mensaje = ObtenerValor(elemento, "Msg") ?? "";

        return $"[{codigo}] {mensaje}";
    }

    internal static string ObtenerErrorSoap(string contenido)
    {
        try
        {
            var documento = XDocument.Parse(contenido);

            var fault = documento.Descendants()
                .FirstOrDefault(x => x.Name.LocalName == "Fault");

            if (fault != null)
            {
                return fault.Descendants()
                    .FirstOrDefault(x =>
                        x.Name.LocalName == "faultstring" ||
                        x.Name.LocalName == "Text")
                    ?.Value ?? "Error SOAP sin descripción.";
            }
        }
        catch
        {
            // No exponemos contenido HTTP arbitrario.
        }

        return "No se pudo interpretar la respuesta SOAP.";
    }

    internal static string FormatearImporteArca(decimal importe)
    {
        return importe.ToString(
            "0.00",
            CultureInfo.InvariantCulture);
    }

    internal static DateOnly? ParsearFechaArca(string? fecha)
    {
        if (string.IsNullOrWhiteSpace(fecha))
            return null;

        return DateOnly.TryParseExact(
            fecha,
            "yyyyMMdd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var resultado)
            ? resultado
            : throw new InvalidOperationException(
                "ARCA devolvió una fecha fiscal inválida.");
    }

    internal static List<string> ObtenerMensajesArca(
        XElement resultado,
        string contenedor,
        string elemento)
    {
        return resultado.Descendants()
            .Where(x => x.Name.LocalName == contenedor)
            .SelectMany(x => x.Elements())
            .Where(x => x.Name.LocalName == elemento)
            .Select(FormatearMensaje)
            .ToList();
    }
}
