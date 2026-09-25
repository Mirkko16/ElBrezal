using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Desktop.UI.Styles;

namespace ElBrezal.Desktop.Forms.Articulos.StockMinimo
{
    public partial class StockMinimoForm : Form
    {
        private readonly IProductoService _productoService;

        private List<ProductoDto> _productos = new();

        public StockMinimoForm(
            IProductoService productoService)
        {
            InitializeComponent();

            _productoService = productoService;
        }

        private async void StockMinimoForm_Load(
            object sender,
            EventArgs e)
        {
            ConfigurarGrilla();

            await CargarProductosAsync();

            textBoxBuscarProducto.Focus();
        }

        #region Configuración

        private void ConfigurarGrilla()
        {
            DataGridViewStyles.AplicarEstiloBase(
                dataGridViewStockMinimos);

            dataGridViewStockMinimos.AutoGenerateColumns = false;

            dataGridViewStockMinimos.ReadOnly = true;

            dataGridViewStockMinimos.AllowUserToAddRows = false;
            dataGridViewStockMinimos.AllowUserToDeleteRows = false;

            dataGridViewStockMinimos.MultiSelect = false;

            dataGridViewStockMinimos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            DataGridViewTextBoxColumnArticulo.DataPropertyName =
                nameof(ProductoDto.Id);

            DataGridViewTextBoxColumnDescripcion.DataPropertyName =
                nameof(ProductoDto.Nombre);

            DataGridViewTextBoxColumnStock.DataPropertyName =
                nameof(ProductoDto.Stock);

            DataGridViewTextBoxColumnStockMinimo.DataPropertyName =
                nameof(ProductoDto.StockMinimo);

            DataGridViewTextBoxColumnStock.DefaultCellStyle.Format =
                "N2";

            DataGridViewTextBoxColumnStockMinimo.DefaultCellStyle.Format =
                "N2";
        }

        #endregion

        #region Carga de datos

        private async Task CargarProductosAsync()
        {
            try
            {
                _productos =
                    await _productoService
                        .ObtenerConStockMinimoAsync();

                MostrarProductos(_productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar los productos.\n\n{ex.Message}",
                    "Stocks mínimos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarProductos(
            IEnumerable<ProductoDto> productos)
        {
            dataGridViewStockMinimos.DataSource =
                productos.ToList();
        }

        #endregion

        #region Búsqueda

        private void textBoxBuscarProducto_TextChanged(
            object sender,
            EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            string filtro =
                textBoxBuscarProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                MostrarProductos(_productos);
                return;
            }

            var productosFiltrados =
                _productos
                    .Where(x =>
                        x.Nombre.Contains(
                            filtro,
                            StringComparison.OrdinalIgnoreCase) ||
                        x.Id.ToString().Contains(filtro))
                    .ToList();

            MostrarProductos(productosFiltrados);
        }

        #endregion

        #region Botones

        private void btnSalir_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        #endregion

        private void StockMinimoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}