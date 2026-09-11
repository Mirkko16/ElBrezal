using System;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Main
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

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

    }
}