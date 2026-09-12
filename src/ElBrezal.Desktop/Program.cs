using ElBrezal.Desktop.Forms.Main;
using ElBrezal.Desktop.Forms.Splash;
using ElBrezal.Desktop.Forms.Tablas.Familias;
using ElBrezal.Desktop.Forms.Tablas.Marcas;
using ElBrezal.Desktop.Forms.Tablas.Unidades;
using ElBrezal.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElBrezal.Desktop;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration
                    .GetConnectionString("ElBrezalDb")
                    ?? throw new InvalidOperationException(
                        "No se encontró la connection string 'ElBrezalDb'.");

                services.AddInfrastructure(connectionString);

                services.AddTransient<MainForm>();
                services.AddTransient<MarcasForm>();
                services.AddTransient<FamiliasForm>();
                services.AddTransient<UnidadesForm>();
            })
            .Build();

        using (var splash = new SplashForm())
        {
            splash.ShowDialog();
        }

        var mainForm = host.Services.GetRequiredService<MainForm>();

        System.Windows.Forms.Application.Run(mainForm);
    }
}