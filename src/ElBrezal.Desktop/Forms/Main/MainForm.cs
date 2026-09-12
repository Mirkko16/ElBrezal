using ElBrezal.Desktop.Forms.Tablas.Marcas;
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
    }
}