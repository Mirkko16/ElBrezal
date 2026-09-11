using ElBrezal.Desktop.Forms.Main;

namespace ElBrezal.Desktop;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        System.Windows.Forms.Application.Run(new MainForm());
    }
}