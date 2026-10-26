
namespace ElBrezal.Infrastructure.ARCA;

/// <summary>
/// Datos fiscales utilizados por la instalación actual
/// para comunicarse con ARCA.
/// </summary>
public sealed class ArcaEmisorOptions
{
    public long CuitEmisor { get; set; }

    public string Ambiente { get; set; } = "HOMOLOGACION";

    public string RutaCertificadoPfx { get; set; } = string.Empty;
}
