using ElBrezal.Application.Interfaces.Comprobantes;
using ElBrezal.Application.Models.Comprobantes;
using ElBrezal.Desktop.UI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Comprobantes.BusquedaComprobantes
{
    public partial class BuscarComprobanteForm : Form
    {
        private readonly IComprobanteService _comprobanteService;
        private readonly string _abreviaturaTipo;

        private List<BuscarComprobanteDto> _comprobantes = new();

        public BuscarComprobanteDto? ComprobanteSeleccionado { get; private set; }

        public BuscarComprobanteForm(
            IComprobanteService comprobanteService,
            string abreviaturaTipo)
        {
            InitializeComponent();

            _comprobanteService = comprobanteService;
            _abreviaturaTipo = abreviaturaTipo;
        }

        private async void BuscarComprobanteForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();

            lblTipoComprobante.Text =
                $"BUSCAR {ObtenerNombreTipo()}";

            await BuscarAsync();
        }

        private void ConfigurarGrilla()
        {
            DataGridViewStyles.AplicarEstiloBase(dataGridViewComprobantes);

            dataGridViewComprobantes.AllowUserToAddRows = false;
            dataGridViewComprobantes.AllowUserToDeleteRows = false;
            dataGridViewComprobantes.ReadOnly = true;

            dataGridViewComprobantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewComprobantes.MultiSelect = false;

            dataGridViewComprobantes.Columns[DataGridViewTextBoxFecha.Name].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridViewComprobantes.Columns[DataGridViewTextBoxTotal.Name].DefaultCellStyle.Format = "N2";

            dataGridViewComprobantes.Columns[DataGridViewTextBoxTotal.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void textBoxPuntoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }

        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private async Task BuscarAsync()
        {
            try
            {
                int? puntoVenta =
                    ObtenerNumeroOpcional(textBoxPuntoVenta.Text);

                int? numero =
                    ObtenerNumeroOpcional(textBoxNumero.Text);

                _comprobantes =
                    await _comprobanteService.BuscarAsync(
                        _abreviaturaTipo,
                        puntoVenta,
                        numero);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron buscar los comprobantes.\n\n{ex.Message}",
                    "Buscar comprobante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla()
        {
            dataGridViewComprobantes.Rows.Clear();

            foreach (var comprobante in _comprobantes)
            {
                int indice =
                    dataGridViewComprobantes.Rows.Add();

                var fila =
                    dataGridViewComprobantes.Rows[indice];

                fila.Tag = comprobante;

                fila.Cells[DataGridViewTextBoxFecha.Name].Value = comprobante.Fecha;

                fila.Cells[DataGridViewTextBoxNumero.Name].Value = $"{comprobante.PuntoVenta:0000}-" + $"{comprobante.Numero:000000}";

                fila.Cells[DataGridViewTextBoxCliente.Name].Value = comprobante.Cliente;

                fila.Cells[DataGridViewTextBoxTotal.Name].Value = comprobante.Total;
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await BuscarAsync();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SeleccionarComprobante();
        }

        private void dataGridViewComprobantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SeleccionarComprobante();
        }

        private void SeleccionarComprobante()
        {
            if (dataGridViewComprobantes.CurrentRow?.Tag
                is not BuscarComprobanteDto comprobante)
            {
                MessageBox.Show(
                    "Seleccione un comprobante.",
                    "Buscar comprobante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            ComprobanteSeleccionado = comprobante;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private static int? ObtenerNumeroOpcional(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return null;

            return int.TryParse(texto, out int valor)
                ? valor
                : null;
        }

        private string ObtenerNombreTipo()
        {
            return _abreviaturaTipo switch
            {
                "FA" => "FACTURA A",
                "FB" => "FACTURA B",
                "FC" => "FACTURA C",
                "REMI" => "REMITO",
                _ => "COMPROBANTE"
            };
        }
    }
}