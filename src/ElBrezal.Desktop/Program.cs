using ElBrezal.Desktop.Forms.Main;
using ElBrezal.Desktop.Forms.Splash;

namespace ElBrezal.Desktop;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using (var splash = new SplashForm())
        {
            splash.ShowDialog();
        }

        System.Windows.Forms.Application.Run(new MainForm());
    }
}