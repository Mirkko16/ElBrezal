using ElBrezal.Desktop.Forms.Articulos.ActualizacionCostos;
using ElBrezal.Desktop.Forms.Articulos.Actualizaciones;
using ElBrezal.Desktop.Forms.Articulos.StockMinimo;
using ElBrezal.Desktop.Forms.Clientes.ActualizacionClientes;
using ElBrezal.Desktop.Forms.Clientes.Presupuesto;
using ElBrezal.Desktop.Forms.Clientes.Remitos;
using ElBrezal.Desktop.Forms.Clientes.Ventas;
using ElBrezal.Desktop.Forms.Main;
using ElBrezal.Desktop.Forms.Splash;
using ElBrezal.Desktop.Forms.Tablas.Familias;
using ElBrezal.Desktop.Forms.Tablas.Localidades;
using ElBrezal.Desktop.Forms.Tablas.Marcas;
using ElBrezal.Desktop.Forms.Tablas.Proveedores;
using ElBrezal.Desktop.Forms.Tablas.Unidades;
using ElBrezal.Desktop.Forms.Tablas.Vendedores;
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
                services.AddTransient<LocalidadesForm>();
                services.AddTransient<ClientesForm>();
                services.AddTransient<VendedoresForm>();
                services.AddTransient<ProveedoresForm>();
                services.AddTransient<ArticulosForm>();
                services.AddTransient<ActualizacionCostosForm>();
                services.AddTransient<VentaForm>();
                services.AddTransient<PresupuestoForm>();
                services.AddTransient<RemitoForm>();
                services.AddTransient<StockMinimoForm>();

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