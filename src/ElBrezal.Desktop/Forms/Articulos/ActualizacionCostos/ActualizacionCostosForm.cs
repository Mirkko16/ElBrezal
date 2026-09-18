using ElBrezal.Application.ActualizacionCostos;
using ElBrezal.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Articulos.ActualizacionCostos
{
    public partial class ActualizacionCostosForm : Form
    {
        private readonly IActualizacionCostosService _actualizacionCostosService;
        private readonly IFamiliaService _familiaService;
        private readonly IMarcaService _marcaService;
        private readonly IProveedorService _proveedorService;

        private BindingList<ActualizacionCostoProductoDto> _productos = new();

        public ActualizacionCostosForm(
            IActualizacionCostosService actualizacionCostosService,
            IFamiliaService familiaService,
            IMarcaService marcaService,
            IProveedorService proveedorService)
        {
            InitializeComponent();

            _actualizacionCostosService = actualizacionCostosService;
            _familiaService = familiaService;
            _marcaService = marcaService;
            _proveedorService = proveedorService;
        }

        private async void ActualizacionCostosForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();

                await CargarCombosAsync();

                radioButtonPorcentaje.Checked = true;

                btnAplicarActualizacion.Enabled = false;

                lblResultado.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar el formulario.\n\n{ex.Message}",
                    "Actualización de costos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task CargarCombosAsync()
        {
            var familias = await _familiaService.ObtenerTodasAsync();
            var marcas = await _marcaService.ObtenerTodasAsync();
            var proveedores = await _proveedorService.ObtenerTodosAsync();

            comboBoxFamilia.DataSource = familias;
            comboBoxFamilia.DisplayMember = "Nombre";
            comboBoxFamilia.ValueMember = "Id";
            comboBoxFamilia.SelectedIndex = -1;

            comboBoxMarca.DataSource = marcas;
            comboBoxMarca.DisplayMember = "Nombre";
            comboBoxMarca.ValueMember = "Id";
            comboBoxMarca.SelectedIndex = -1;

            comboBoxProveedor.DataSource = proveedores;
            comboBoxProveedor.DisplayMember = "Nombre";
            comboBoxProveedor.ValueMember = "Id";
            comboBoxProveedor.SelectedIndex = -1;
        }

        private void ConfigurarGrilla()
        {
            dataGridViewProductos.AutoGenerateColumns = false;
            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = false;
            dataGridViewProductos.MultiSelect = false;

            // IMPORTANTE:
            // La grilla debe permitir edición.
            // Después bloqueamos individualmente las columnas de texto.
            dataGridViewProductos.ReadOnly = false;

            dataGridViewProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            DataGridViewCheckBoxColumnSeleccionar.DataPropertyName =
                nameof(ActualizacionCostoProductoDto.Seleccionado);

            DataGridViewCheckBoxColumnSeleccionar.ReadOnly = false;

            DataGridViewTextBoxColumnCodigo.DataPropertyName =
                nameof(ActualizacionCostoProductoDto.Codigo);

            DataGridViewTextBoxColumnProducto.DataPropertyName =
                nameof(ActualizacionCostoProductoDto.Nombre);

            DataGridViewTextBoxFamilia.DataPropertyName =
                nameof(ActualizacionCostoProductoDto.Familia);

            DataGridViewTextBoxColumnMarca.DataPropertyName =
                nameof(ActualizacionCostoProductoDto.Marca);

            DataGridViewTextBoxColumnProveedor.DataPropertyName =
                nameof(ActualizacionCostoProductoDto.Proveedor);

            DataGridViewTextBoxColumnPrecioContado.DataPropertyName =
    nameof(ActualizacionCostoProductoDto.PrecioContado);

            DataGridViewTextBoxColumnPrecioContado.ReadOnly = true;
            DataGridViewTextBoxColumnPrecioContado.DefaultCellStyle.Format = "N2";

            DataGridViewTextBoxColumnCodigo.ReadOnly = true;
            DataGridViewTextBoxColumnProducto.ReadOnly = true;
            DataGridViewTextBoxFamilia.ReadOnly = true;
            DataGridViewTextBoxColumnMarca.ReadOnly = true;
            DataGridViewTextBoxColumnProveedor.ReadOnly = true;
            

            bindingSourceProductos.DataSource = _productos;
            dataGridViewProductos.DataSource = bindingSourceProductos;

            dataGridViewProductos.CurrentCellDirtyStateChanged +=
                dataGridViewProductos_CurrentCellDirtyStateChanged;
        }


        private void dataGridViewProductos_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridViewProductos.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridViewProductos.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }
        private async void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuscarProductos.Enabled = false;

                await BuscarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al buscar los productos.\n\n{ex.Message}",
                    "Actualización de costos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscarProductos.Enabled = true;
            }
        }

        private async Task BuscarProductosAsync()
        {
            int? familiaId = ObtenerIdSeleccionado(comboBoxFamilia);
            int? marcaId = ObtenerIdSeleccionado(comboBoxMarca);
            int? proveedorId = ObtenerIdSeleccionado(comboBoxProveedor);

            var resultado =
                await _actualizacionCostosService.BuscarProductosAsync(
                    familiaId,
                    marcaId,
                    proveedorId);

            _productos =
                new BindingList<ActualizacionCostoProductoDto>(resultado);

            bindingSourceProductos.DataSource = _productos;

            lblResultado.Text =
                $"{_productos.Count}";

            btnAplicarActualizacion.Enabled = _productos.Count > 0;
        }

        private static int? ObtenerIdSeleccionado(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex < 0 ||
                comboBox.SelectedValue == null)
            {
                return null;
            }

            return Convert.ToInt32(comboBox.SelectedValue);
        }

        private async void btnAplicarActualizacion_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // Confirma cualquier cambio pendiente de un checkbox
                dataGridViewProductos.EndEdit();
                bindingSourceProductos.EndEdit();

                var productosSeleccionados = _productos
                    .Where(x => x.Seleccionado)
                    .ToList();

                if (productosSeleccionados.Count == 0)
                {
                    MessageBox.Show(
                        "Debe seleccionar al menos un producto.",
                        "Actualización de costos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!decimal.TryParse(
                        textBoxAumento.Text,
                        out decimal valor) ||
                    valor <= 0)
                {
                    MessageBox.Show(
                        "Ingrese un valor de aumento válido.",
                        "Actualización de costos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxAumento.Focus();
                    textBoxAumento.SelectAll();

                    return;
                }

                TipoActualizacionCosto tipoActualizacion;

                if (radioButtonPorcentaje.Checked)
                {
                    tipoActualizacion =
                        TipoActualizacionCosto.Porcentaje;
                }
                else if (radioButtonImporte.Checked)
                {
                    tipoActualizacion =
                        TipoActualizacionCosto.Importe;
                }
                else
                {
                    MessageBox.Show(
                        "Seleccione el tipo de aumento.",
                        "Actualización de costos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string descripcionAumento =
                    tipoActualizacion == TipoActualizacionCosto.Porcentaje
                        ? $"{valor:N2}%"
                        : $"${valor:N2}";

                var respuesta = MessageBox.Show(
                    $"Se actualizarán {productosSeleccionados.Count} productos.\n\n" +
                    $"Aumento: {descripcionAumento}\n\n" +
                    "¿Desea aplicar la actualización?",
                    "Confirmar actualización",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (respuesta != DialogResult.Yes)
                    return;

                btnAplicarActualizacion.Enabled = false;
                btnBuscarProductos.Enabled = false;

                await _actualizacionCostosService.AplicarActualizacionAsync(
                    productosSeleccionados.Select(x => x.Id),
                    tipoActualizacion,
                    valor);

                MessageBox.Show(
                    $"Se actualizaron correctamente " +
                    $"{productosSeleccionados.Count} productos.",
                    "Actualización de costos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Refrescamos para mostrar los valores actuales
                await BuscarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al aplicar la actualización.\n\n{ex.Message}",
                    "Actualización de costos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscarProductos.Enabled = true;
                btnAplicarActualizacion.Enabled = _productos.Count > 0;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ActualizacionCostosForm_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
