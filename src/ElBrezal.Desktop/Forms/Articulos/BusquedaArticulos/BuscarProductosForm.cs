using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Desktop.UI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Articulos.BusquedaArticulos
{
    public partial class BuscarProductosForm : Form
    {
        private readonly IProductoService _productoService;

        private List<ProductoDto> _productos = new();

        public ProductoDto? ProductoSeleccionado { get; private set; }

        public BuscarProductosForm(IProductoService productoService)
        {
            InitializeComponent();

            _productoService = productoService;
        }

        private async void BuscarProductosForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();

            _productos = await _productoService.ObtenerTodosAsync();

            MostrarProductos(_productos);

            textBoxBuscar.Focus();
        }

        private void ConfigurarGrilla()
        {
            DataGridViewStyles.AplicarEstiloBase(dataGridViewProductos);

            dataGridViewProductos.ReadOnly = true;
            dataGridViewProductos.MultiSelect = false;
            dataGridViewProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = false;
            dataGridViewProductos.AutoGenerateColumns = false;

            // Binding de columnas
            dataGridViewTextBoxColumnCodigo.DataPropertyName =
                nameof(ProductoDto.Id);

            dataGridViewTextBoxColumnDescripcion.DataPropertyName =
                nameof(ProductoDto.Nombre);

            dataGridViewTextBoxColumnStock.DataPropertyName =
                nameof(ProductoDto.Stock);

            // Formato numérico para el stock (2 decimales)
            dataGridViewTextBoxColumnStock.DefaultCellStyle.Format = "N2";
            // Alinea el número a la derecha (opcional, pero recomendado para números)
            dataGridViewTextBoxColumnStock.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Distribución
            dataGridViewTextBoxColumnCodigo.FillWeight = 12;
            dataGridViewTextBoxColumnDescripcion.FillWeight = 45;
            dataGridViewTextBoxColumnStock.FillWeight = 20;
        }
        private void MostrarProductos(IEnumerable<ProductoDto> productos)
        {
            dataGridViewProductos.DataSource = productos.ToList();

            if (dataGridViewProductos.Rows.Count == 0)
                return;

            dataGridViewProductos.ClearSelection();

            dataGridViewProductos.Rows[0].Selected = true;
            dataGridViewProductos.CurrentCell =
                dataGridViewProductos.Rows[0].Cells[0];
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            var texto = textBoxBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarProductos(_productos);
                return;
            }

            var productosFiltrados = _productos
                .Where(x =>
                    x.Id.ToString().Contains(texto) ||
                    x.Nombre.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase
                    ))
                .ToList();

            MostrarProductos(productosFiltrados);
        }

        private void SeleccionarProducto()
        {
            if (dataGridViewProductos.CurrentRow?.DataBoundItem
                is not ProductoDto producto)
            {
                return;
            }

            ProductoSeleccionado = producto;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridViewProductos_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SeleccionarProducto();
        }

        private void dataGridViewProductos_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            SeleccionarProducto();
        }

        private void textBoxBuscar_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                MoverSeleccion(1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoverSeleccion(-1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SeleccionarProducto();
                e.SuppressKeyPress = true;
            }
        }

        private void MoverSeleccion(int direccion)
        {
            if (dataGridViewProductos.Rows.Count == 0)
                return;

            int indiceActual =
                dataGridViewProductos.CurrentRow?.Index ?? 0;

            int nuevoIndice = Math.Clamp(
                indiceActual + direccion,
                0,
                dataGridViewProductos.Rows.Count - 1);

            dataGridViewProductos.ClearSelection();

            dataGridViewProductos.Rows[nuevoIndice].Selected = true;

            dataGridViewProductos.CurrentCell =
                dataGridViewProductos.Rows[nuevoIndice].Cells[0];
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
