using System.Text;

namespace ElBrezal.Infrastructure.ARCA;

/// <summary>
/// Registra eventos técnicos de WSFEv1 sin almacenar Token, Sign ni el XML SOAP.
/// Los archivos se guardan en la carpeta de datos del usuario de Windows.
/// </summary>
internal sealed class ArcaLogger
{
    private static readonly SemaphoreSlim Semaforo = new(1, 1);
    private readonly string _directorio;

    public ArcaLogger()
    {
        _directorio = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ElBrezal", "logs", "arca");
    }

    /// <summary>Agrega una línea al log diario de ARCA.</summary>
    public async Task EscribirAsync(string nivel, string operacion, string mensaje)
    {
        await Semaforo.WaitAsync();
        try
        {
            Directory.CreateDirectory(_directorio);
            string archivo = Path.Combine(_directorio, $"arca-{DateTime.Now:yyyy-MM-dd}.log");
            string registro = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                $"[{nivel}] [{operacion}] " +
                mensaje.Replace("\r", " ").Replace("\n", " ") + Environment.NewLine;
            await File.AppendAllTextAsync(archivo, registro, Encoding.UTF8);
        }
        finally
        {
            Semaforo.Release();
        }
    }
}
