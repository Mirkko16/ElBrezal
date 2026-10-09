using ElBrezal.Application.Interfaces.Clientes;
using ElBrezal.Application.Interfaces.Comprobantes;
using ElBrezal.Application.Models.Comprobantes;
using ElBrezal.Desktop.Forms.Clientes;
using ElBrezal.Desktop.Printing;
using ElBrezal.Desktop.UI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Comprobantes
{
    public partial class ListadoVentasDetalladasForm : Form
    {
        private readonly IComprobanteService _comprobanteService;
        private readonly ITipoComprobanteService _tipoComprobanteService;
        private readonly IClienteService _clienteService;
        private List<ComprobanteListadoDto> _comprobantes = new();
        private readonly ComprobanteImpresionService _comprobanteImpresionService;
        private int? _clienteId;
        private bool _formularioCargado;

        public ListadoVentasDetalladasForm(IComprobanteService comprobanteService, ITipoComprobanteService tipoComprobanteService,
            IClienteService clienteService, ComprobanteImpresionService comprobanteImpresionService)
        {
            InitializeComponent();

            _comprobanteService = comprobanteService;
            _tipoComprobanteService = tipoComprobanteService;
            _clienteService = clienteService;
            _comprobanteImpresionService = comprobanteImpresionService;
        }

        private async void ListadoVentasDetalladasForm_Load(object sender, EventArgs e)
        {
            try
            {
                _formularioCargado = false;

                ConfigurarGrillaComprobantes();

                dateTimePickerDesde.Value =
                    new DateTime(
                        DateTime.Today.Year,
                        DateTime.Today.Month,
                        1);

                dateTimePickerHasta.Value =
                    DateTime.Today;

                LimpiarFiltroCliente();

                await CargarTiposComprobanteAsync();

                _formularioCargado = true;

                await CargarComprobantesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar los comprobantes.\n\n{ex.Message}",
                    "Comprobantes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region //Configuracion de la grilla
        private void ConfigurarGrillaComprobantes()
        {
            DataGridViewStyles.AplicarEstiloBase(dataGridViewComprobantes);

            dataGridViewComprobantes.AllowUserToAddRows = false;
            dataGridViewComprobantes.AllowUserToDeleteRows = false;

            dataGridViewComprobantes.MultiSelect = false;
            dataGridViewComprobantes.ReadOnly = true;

            dataGridViewComprobantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewComprobantes.ScrollBars = ScrollBars.Vertical;

            // Formatos
            DataGridViewTextBoxFecha.DefaultCellStyle.Format = "dd/MM/yyyy";

            DataGridViewTextBoxTotal.DefaultCellStyle.Format = "N2";

            // Alineación
            DataGridViewTextBoxFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxNumero.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxCuenta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Distribución del ancho
            DataGridViewTextBoxFecha.FillWeight = 14;
            DataGridViewTextBoxTipo.FillWeight = 9;
            DataGridViewTextBoxNumero.FillWeight = 15;
            DataGridViewTextBoxCuenta.FillWeight = 10;
            DataGridViewTextBoxCliente.FillWeight = 35;
            DataGridViewTextBoxVendedor.FillWeight = 14;
            DataGridViewTextBoxCondicion.FillWeight = 14;
            DataGridViewTextBoxTotal.FillWeight = 19;
        }
        #endregion

        private async void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            await BuscarClienteAsync();
        }


        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            var fila = dataGridViewComprobantes.SelectedRows
                .Cast<DataGridViewRow>()
                .FirstOrDefault();

            if (fila?.Tag is not int comprobanteId)
            {
                MessageBox.Show(
                    this,
                    "Seleccione un comprobante de la grilla para imprimir.",
                    "Imprimir comprobante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            try
            {
                btnImprimir.Enabled = false;
                Cursor = Cursors.WaitCursor;

                await _comprobanteImpresionService.AbrirVistaPreviaAsync(
                    comprobanteId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "No fue posible generar o abrir el comprobante.\n\n" +
                    ex.Message,
                    "Error de impresión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnImprimir.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private async Task CargarTiposComprobanteAsync()
        {
            var tipos = await _tipoComprobanteService.ObtenerTodosAsync();

            var items = tipos
                .Select(x => new
                {
                    Id = (int?)x.Id,
                    Nombre = x.Nombre
                })
                .ToList();

            items.Insert(0, new
            {
                Id = (int?)null,
                Nombre = "TODOS"
            });

            cmbTipoComprobante.DisplayMember = "Nombre";
            cmbTipoComprobante.ValueMember = "Id";
            cmbTipoComprobante.DataSource = items;

            var facturaA = tipos.FirstOrDefault(x =>
                string.Equals(
                    x.Abreviatura,
                    "FA",
                    StringComparison.OrdinalIgnoreCase));

            if (facturaA is not null)
            {
                cmbTipoComprobante.SelectedValue =
                    (int?)facturaA.Id;
            }
        }

        private async Task CargarComprobantesAsync()
        {
            int? tipoComprobanteId = null;

            if (cmbTipoComprobante.SelectedValue is int id)
            {
                tipoComprobanteId = id;
            }

            _comprobantes =
                await _comprobanteService.ObtenerListadoAsync(
                    tipoComprobanteId,
                    dateTimePickerDesde.Value.Date,
                    dateTimePickerHasta.Value.Date,
                    _clienteId);

            dataGridViewComprobantes.Rows.Clear();

            foreach (var comprobante in _comprobantes)
            {
                var indice =
                    dataGridViewComprobantes.Rows.Add();

                var fila =
                    dataGridViewComprobantes.Rows[indice];

                fila.Tag = comprobante.Id;

                fila.Cells[DataGridViewTextBoxFecha.Name].Value =
                    comprobante.Fecha;

                fila.Cells[DataGridViewTextBoxTipo.Name].Value =
                    comprobante.Tipo;

                fila.Cells[DataGridViewTextBoxNumero.Name].Value =
                    $"{comprobante.PuntoVenta:0000}-{comprobante.Numero:000000}";

                fila.Cells[DataGridViewTextBoxCuenta.Name].Value =
                    comprobante.ClienteId;

                fila.Cells[DataGridViewTextBoxCliente.Name].Value =
                    comprobante.Cliente;

                fila.Cells[DataGridViewTextBoxVendedor.Name].Value =
                    comprobante.Vendedor;

                fila.Cells[DataGridViewTextBoxCondicion.Name].Value =
                    comprobante.CondicionVenta;

                fila.Cells[DataGridViewTextBoxTotal.Name].Value =
                    comprobante.Total;
            }

            ActualizarTotales();
            dataGridViewComprobantes.ClearSelection();
        }

        private void LimpiarFiltroCliente()
        {
            _clienteId = null;

            textBoxNumCuenta.Clear();
            textBoxNombreCliente.Clear();
        }



        private async Task AplicarFiltrosAsync()
        {
            if (dateTimePickerDesde.Value.Date > dateTimePickerHasta.Value.Date)
            {
                return;
            }

            try
            {
                await CargarComprobantesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al consultar los comprobantes.\n\n{ex.Message}",
                    "Comprobantes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void cmbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_formularioCargado)
                return;

            await AplicarFiltrosAsync();
        }

        private async void textBoxCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete &&
                e.KeyCode != Keys.Back)
            {
                return;
            }

            e.SuppressKeyPress = true;

            _clienteId = null;
            textBoxNombreCliente.Clear();

            await AplicarFiltrosAsync();
        }

        private async void textBoxNumCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.SuppressKeyPress = true;

                await BuscarClienteAsync();
                return;
            }

            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            if (string.IsNullOrWhiteSpace(textBoxNumCuenta.Text))
            {
                LimpiarFiltroCliente();

                await AplicarFiltrosAsync();
                return;
            }

            if (!int.TryParse(
                    textBoxNumCuenta.Text.Trim(),
                    out var numeroCuenta))
            {
                MessageBox.Show(
                    "El número de cuenta ingresado no es válido.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNumCuenta.Focus();
                textBoxNumCuenta.SelectAll();

                return;
            }

            await CargarClienteFiltroAsync(numeroCuenta);
        }

        private void textBoxNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async Task CargarClienteFiltroAsync(int numeroCuenta)
        {
            var cliente =
                await _clienteService.ObtenerPorIdAsync(numeroCuenta);

            if (cliente is null)
            {
                MessageBox.Show(
                    $"No existe el cliente N° {numeroCuenta}.",
                    "Cliente no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                LimpiarFiltroCliente();

                textBoxNumCuenta.Focus();
                textBoxNumCuenta.SelectAll();

                return;
            }

            _clienteId = cliente.Id;

            textBoxNumCuenta.Text =
                cliente.Id.ToString();

            textBoxNombreCliente.Text =
                cliente.Nombre;

            await AplicarFiltrosAsync();
        }

        private async Task BuscarClienteAsync()
        {
            using var form =
                new BuscarClientesForm(_clienteService);

            if (form.ShowDialog(this) != DialogResult.OK ||
                form.ClienteSeleccionado is null)
            {
                return;
            }

            var cliente = form.ClienteSeleccionado;

            _clienteId = cliente.Id;

            textBoxNumCuenta.Text =
                cliente.Id.ToString();

            textBoxNombreCliente.Text =
                cliente.Nombre;

            await AplicarFiltrosAsync();
        }

        private async void dateTimePickerDesde_ValueChanged(object sender, EventArgs e)
        {
            if (!_formularioCargado)
                return;

            await AplicarFiltrosAsync();
        }

        private async void dateTimePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            if (!_formularioCargado)
                return;

            await AplicarFiltrosAsync();
        }

        private void ActualizarTotales()
        {
            lblCantidadComprobantes.Text =
                _comprobantes.Count.ToString();

            lblTotalComprobantes.Text =
                _comprobantes
                    .Sum(x => x.Total)
                    .ToString("N2");
        }

        private void ListadoVentasDetalladasForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Close();
            }
        }
    }

}
