using ElBrezal.Desktop.Forms.Articulos.Actualizaciones;
using ElBrezal.Desktop.Forms.Clientes.ActualizacionClientes;
using ElBrezal.Desktop.Forms.Tablas.Familias;
using ElBrezal.Desktop.Forms.Tablas.Localidades;
using ElBrezal.Desktop.Forms.Tablas.Marcas;
using ElBrezal.Desktop.Forms.Tablas.Proveedores;
using ElBrezal.Desktop.Forms.Tablas.Unidades;
using ElBrezal.Desktop.Forms.Tablas.Vendedores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;


namespace ElBrezal.Desktop.Forms.Main
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;

            ActualizarFechaHora();
            clockTimer.Tick += ClockTimer_Tick;
        }

        private void ClockTimer_Tick(object? sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            var ahora = DateTime.Now;

            toolStripStatusLabelFecha.Text = ahora.ToString("dd/MM/yyyy");
            toolStripStatusLabelHora.Text = ahora.ToString("HH:mm");
        }
        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioAbierto = MdiChildren
                .OfType<MarcasForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<MarcasForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();
        }

        private void familiaToolStripMenuItem_Click(object sender, EventArgs e)

        {
            var formularioAbierto = MdiChildren
                .OfType<FamiliasForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<FamiliasForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();

        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioAbierto = MdiChildren
                .OfType<UnidadesForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<UnidadesForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioAbierto = MdiChildren
                .OfType<LocalidadesForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<LocalidadesForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();

        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioAbierto = MdiChildren
                .OfType<VendedoresForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<VendedoresForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();

        }

        private void actualizacionClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioAbierto = MdiChildren
                .OfType<ClientesForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<ClientesForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();

        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var formularioAbierto = MdiChildren
                .OfType<ProveedoresForm>()
                .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<ProveedoresForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();

        }

        private void actualizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formularioAbierto = MdiChildren
               .OfType<ArticulosForm>()
               .FirstOrDefault();

            if (formularioAbierto is not null)
            {
                formularioAbierto.Activate();
                return;
            }

            var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<ArticulosForm>();

            form.MdiParent = this;

            form.FormClosed += (_, _) =>
            {
                scope.Dispose();
            };

            form.Show();

        }
    }
}