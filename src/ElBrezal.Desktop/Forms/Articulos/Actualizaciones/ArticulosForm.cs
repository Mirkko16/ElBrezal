using ElBrezal.Application.Calculations;
using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Desktop.Forms.Tablas.Familias;
using ElBrezal.Desktop.Forms.Tablas.Marcas;
using ElBrezal.Desktop.Forms.Tablas.Proveedores;
using ElBrezal.Desktop.Forms.Tablas.Unidades;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ElBrezal.Desktop.Forms.Articulos.Actualizaciones
{
    public partial class ArticulosForm : Form
    {
        private readonly IProductoService _productoService;
        private readonly IFamiliaService _familiaService;
        private readonly IMarcaService _marcaService;
        private readonly IUnidadService _unidadService;
        private readonly IProveedorService _proveedorService;
        private readonly IAlicuotaIVAService _alicuotaIVAService;
        private readonly IServiceProvider _serviceProvider;

        private List<ProductoDto> _productos = new();

        private ModoFormulario _modo = ModoFormulario.Consulta;

        private enum ModoFormulario
        {
            Consulta,
            Nuevo,
            Modificar
        }

        public ArticulosForm(
            IProductoService productoService,
            IFamiliaService familiaService,
            IMarcaService marcaService,
            IUnidadService unidadService,
            IProveedorService proveedorService,
            IAlicuotaIVAService alicuotaIVAService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _productoService = productoService;
            _familiaService = familiaService;
            _marcaService = marcaService;
            _unidadService = unidadService;
            _proveedorService = proveedorService;
            _alicuotaIVAService = alicuotaIVAService;
            _serviceProvider = serviceProvider;
        }

        private async void ArticulosForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();

                await CargarCombosAsync();
                await CargarProductosAsync();

                CambiarModo(ModoFormulario.Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar los artículos.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #region Carga de datos

        private async Task CargarCombosAsync()
        {
            await CargarFamiliasAsync();
            await CargarMarcasAsync();
            await CargarUnidadesAsync();
            await CargarProveedoresAsync();
            await CargarAlicuotasIVAAsync();
        }

        private async Task CargarFamiliasAsync()
        {
            var familias = await _familiaService.ObtenerTodasAsync();

            bindingSourceFamilia.DataSource = familias;

            comboBoxFamilia.DataSource = bindingSourceFamilia;
            comboBoxFamilia.DisplayMember = "Nombre";
            comboBoxFamilia.ValueMember = "Id";
        }

        private async Task CargarMarcasAsync()
        {
            var marcas = await _marcaService.ObtenerTodasAsync();

            bindingSourceMarca.DataSource = marcas;

            comboBoxMarca.DataSource = bindingSourceMarca;
            comboBoxMarca.DisplayMember = "Nombre";
            comboBoxMarca.ValueMember = "Id";
        }

        private async Task CargarUnidadesAsync()
        {
            var unidades = await _unidadService.ObtenerTodasAsync();

            bindingSourceUnidad.DataSource = unidades;

            comboBoxUnidad.DataSource = bindingSourceUnidad;
            comboBoxUnidad.DisplayMember = "Descripcion";
            comboBoxUnidad.ValueMember = "Id";
        }

        private async Task CargarProveedoresAsync()
        {
            var proveedores = await _proveedorService.ObtenerTodosAsync();

            bindingSourceProveedor.DataSource = proveedores;

            comboBoxProveedor.DataSource = bindingSourceProveedor;
            comboBoxProveedor.DisplayMember = "Nombre";
            comboBoxProveedor.ValueMember = "Id";
        }

        private async Task CargarAlicuotasIVAAsync()
        {
            var alicuotas = await _alicuotaIVAService.ObtenerTodasAsync();

            bindingSourceAlicuota.DataSource = alicuotas;

            comboBoxAlicuota.DataSource = bindingSourceAlicuota;
            comboBoxAlicuota.DisplayMember = "Nombre";
            comboBoxAlicuota.ValueMember = "Id";
        }

        private async Task CargarProductosAsync(int? seleccionarId = null)
        {
            _productos = await _productoService.ObtenerTodosAsync();

            bindingSourceArticulos.DataSource = _productos;

            if (seleccionarId.HasValue)
            {
                int indice = _productos.FindIndex(
                    x => x.Id == seleccionarId.Value);

                if (indice >= 0)
                    bindingSourceArticulos.Position = indice;
            }

            MostrarProductoActual();
        }

        #endregion

        #region Configuración

        private void ConfigurarControles()
        {
            // Campos controlados por el sistema
            textBoxCodigo.ReadOnly = true;
            textBoxFechaAlta.ReadOnly = true;
            textBoxFechaModificacion.ReadOnly = true;
            textBoxCategoria.ReadOnly = true;

            // IVA es un catálogo cerrado del sistema
            comboBoxAlicuota.DropDownStyle = ComboBoxStyle.DropDownList;

            // Catálogos buscables
            ConfigurarComboBuscable(comboBoxFamilia);
            ConfigurarComboBuscable(comboBoxMarca);
            ConfigurarComboBuscable(comboBoxUnidad);
            ConfigurarComboBuscable(comboBoxProveedor);
        }

        private static void ConfigurarComboBuscable(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        #endregion

        #region Mostrar producto

        private void MostrarProductoActual()
        {
            if (_modo != ModoFormulario.Consulta)
                return;

            if (bindingSourceArticulos.Current is not ProductoDto producto)
            {
                LimpiarCampos();
                ActualizarPosicion();
                return;
            }

            textBoxCodigo.Text = producto.Id.ToString();
            textBoxDescripcion.Text = producto.Nombre;

            comboBoxFamilia.SelectedValue = producto.FamiliaId;
            comboBoxMarca.SelectedValue = producto.MarcaId;
            comboBoxUnidad.SelectedValue = producto.UnidadId;
            comboBoxProveedor.SelectedValue = producto.ProveedorId;

            textBoxFechaAlta.Text =
                producto.FechaAlta.ToString("dd/MM/yyyy");

            textBoxFechaModificacion.Text =
                producto.FechaModificacion?.ToString("dd/MM/yyyy")
                ?? string.Empty;

            textBoxStock.Text =
                producto.Stock.ToString("0.####");

            textBoxCostoArt.Text =
                producto.Costo.ToString("0.00");

            comboBoxAlicuota.SelectedValue =
                producto.AlicuotaIVAId;

            textBoxRentaContado.Text =
                producto.RentabilidadContado.ToString("0.00");

            textBoxContadoSIVA.Text =
                producto.PrecioContado.ToString("0.00");

            textBoxrentaReventa.Text =
                producto.RentabilidadReventa.ToString("0.00");

            textBoxReventaSIVA.Text =
                producto.PrecioReventa.ToString("0.00");

            textBoxRentaCtaCte.Text =
                producto.RentabilidadCuentaCorriente.ToString("0.00");

            textBoxCtaCteSIVA.Text =
                producto.PrecioCuentaCorriente.ToString("0.00");

            ActualizarPreciosConIVA();
            ActualizarCategoria();
            ActualizarPosicion();
        }

        private void LimpiarCampos()
        {
            textBoxCodigo.Clear();
            textBoxDescripcion.Clear();

            comboBoxFamilia.SelectedIndex = -1;
            comboBoxMarca.SelectedIndex = -1;
            comboBoxUnidad.SelectedIndex = -1;
            comboBoxProveedor.SelectedIndex = -1;

            textBoxFechaAlta.Clear();
            textBoxFechaModificacion.Clear();

            textBoxStock.Text = "0";

            textBoxCostoArt.Text = "0,00";

            textBoxRentaContado.Text = "0,00";
            textBoxContadoSIVA.Text = "0,00";

            textBoxrentaReventa.Text = "0,00";
            textBoxReventaSIVA.Text = "0,00";

            textBoxRentaCtaCte.Text = "0,00";
            textBoxCtaCteSIVA.Text = "0,00";

            lblPRecioIVA.Text = "$0,00";
            lblPrecioReventa.Text = "$0,00";
            lblPrecioCtaCte.Text = "$0,00";

            textBoxCategoria.Clear();

            // IVA 21% por defecto
            var iva21 = bindingSourceAlicuota
                .Cast<AlicuotaIVADto>()
                .FirstOrDefault(x => x.Porcentaje == 21m);

            if (iva21 != null)
                comboBoxAlicuota.SelectedValue = iva21.Id;
        }

        #endregion

        #region Modo del formulario

        private void CambiarModo(ModoFormulario modo)
        {
            _modo = modo;

            bool editando =
                modo == ModoFormulario.Nuevo ||
                modo == ModoFormulario.Modificar;

            // Datos editables
            textBoxDescripcion.ReadOnly = !editando;
            textBoxStock.ReadOnly = !editando;
            textBoxCostoArt.ReadOnly = !editando;

            textBoxRentaContado.ReadOnly = !editando;
            textBoxContadoSIVA.ReadOnly = !editando;

            textBoxrentaReventa.ReadOnly = !editando;
            textBoxReventaSIVA.ReadOnly = !editando;

            textBoxRentaCtaCte.ReadOnly = !editando;
            textBoxCtaCteSIVA.ReadOnly = !editando;

            comboBoxFamilia.Enabled = editando;
            comboBoxMarca.Enabled = editando;
            comboBoxUnidad.Enabled = editando;
            comboBoxProveedor.Enabled = editando;
            comboBoxAlicuota.Enabled = editando;

            // Altas rápidas de catálogos
            btnNuevaFamilia.Enabled = editando;
            btnNuevaMarca.Enabled = editando;
            btnNuevaUnidad.Enabled = editando;
            btnNuevoProveedor.Enabled = editando;

            // Navegación
            btnPrimero.Enabled = !editando;
            btnAnterior.Enabled = !editando;
            btnSiguiente.Enabled = !editando;
            btnUltimo.Enabled = !editando;

            // CRUD
            if (modo == ModoFormulario.Nuevo)
            {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";

                btnNuevo.Enabled = true;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = false;
            }
            else if (modo == ModoFormulario.Modificar)
            {
                btnNuevo.Text = "Nuevo";
                btnModificar.Text = "Guardar";

                btnNuevo.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnNuevo.Text = "Nuevo";
                btnModificar.Text = "Modificar";

                btnNuevo.Enabled = true;

                bool hayProductos =
                    bindingSourceArticulos.Count > 0;

                btnModificar.Enabled = hayProductos;
                btnEliminar.Enabled = hayProductos;
            }
        }

        #endregion

        #region Cálculos visuales

        private decimal ObtenerPorcentajeIVA()
        {
            if (comboBoxAlicuota.SelectedItem is AlicuotaIVADto alicuota)
                return alicuota.Porcentaje;

            return 0m;
        }

        private static decimal ObtenerDecimal(string texto)
        {
            return decimal.TryParse(texto, out decimal valor)
                ? valor
                : 0m;
        }

        private void ActualizarPreciosConIVA()
        {
            decimal iva = ObtenerPorcentajeIVA();

            decimal precioContado =
                ObtenerDecimal(textBoxContadoSIVA.Text);

            decimal precioReventa =
                ObtenerDecimal(textBoxReventaSIVA.Text);

            decimal precioCtaCte =
                ObtenerDecimal(textBoxCtaCteSIVA.Text);

            decimal contadoConIVA =
                ProductoCalculador.CalcularPrecioConIVA(
                    precioContado,
                    iva);

            decimal reventaConIVA =
                ProductoCalculador.CalcularPrecioConIVA(
                    precioReventa,
                    iva);

            decimal ctaCteConIVA =
                ProductoCalculador.CalcularPrecioConIVA(
                    precioCtaCte,
                    iva);

            lblPRecioIVA.Text =
                contadoConIVA.ToString("C2");

            lblPrecioReventa.Text =
                reventaConIVA.ToString("C2");

            lblPrecioCtaCte.Text =
                ctaCteConIVA.ToString("C2");
        }

        private void ActualizarCategoria()
        {
            decimal rentabilidad =
                ObtenerDecimal(textBoxRentaContado.Text);

            int categoria =
                ProductoCalculador.CalcularCategoria(
                    rentabilidad);

            textBoxCategoria.Text = string.Empty;

            textBoxCategoria.BackColor = categoria switch
            {
                1 => Color.Green,
                2 => Color.Yellow,
                3 => Color.Red,
                _ => SystemColors.Control
            };
        }

        #endregion

        #region Navegación

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            bindingSourceArticulos.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bindingSourceArticulos.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            bindingSourceArticulos.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            bindingSourceArticulos.MoveLast();
        }

        private void bindingSourceArticulos_PositionChanged(
            object sender,
            EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                MostrarProductoActual();
        }

        private void ActualizarPosicion()
        {
            if (bindingSourceArticulos.Count == 0)
            {
                lblPosicion.Text = "0 de 0";
                return;
            }

            lblPosicion.Text =
                $"{bindingSourceArticulos.Position + 1} de " +
                $"{bindingSourceArticulos.Count}";
        }

        #endregion


        private async void btnNuevaFamilia_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form =
                scope.ServiceProvider.GetRequiredService<FamiliasForm>();

            form.ShowDialog(this);

            await CargarFamiliasAsync();
        }

        private async void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form =
                scope.ServiceProvider.GetRequiredService<MarcasForm>();

            form.ShowDialog(this);

            await CargarMarcasAsync();
        }


        private async void btnNuevaUnidad_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form =
                scope.ServiceProvider.GetRequiredService<UnidadesForm>();

            form.ShowDialog(this);

            await CargarUnidadesAsync();
        }

        private async void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            using var scope = _serviceProvider.CreateScope();

            var form =
                scope.ServiceProvider.GetRequiredService<ProveedoresForm>();

            form.ShowDialog(this);

            await CargarProveedoresAsync();
        }

        private void comboBoxAlicuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarPreciosConIVA();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
            {
                LimpiarCampos();

                textBoxFechaAlta.Text =
                    DateTime.Now.ToString("dd/MM/yyyy");

                CambiarModo(ModoFormulario.Nuevo);

                textBoxDescripcion.Focus();

                return;
            }

            if (_modo != ModoFormulario.Nuevo)
                return;

            if (!ValidarFormulario())
                return;

            try
            {
                var producto = CrearProductoDesdeFormulario();

                await _productoService.AgregarAsync(producto);

                CambiarModo(ModoFormulario.Consulta);

                await CargarProductosAsync();

                // Como ObtenerTodos ordena por Nombre, no hacemos MoveLast.
                // Buscamos el registro recién creado por sus datos.
                var creado = _productos
                    .Where(x => x.Nombre.Equals(
                        producto.Nombre,
                        StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                if (creado != null)
                {
                    int indice = _productos.FindIndex(x => x.Id == creado.Id);

                    if (indice >= 0)
                        bindingSourceArticulos.Position = indice;
                }

                MostrarProductoActual();

                MessageBox.Show(
                    "El artículo se agregó correctamente.",
                    "Artículo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo agregar el artículo.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            // Durante Nuevo, este botón funciona como Cancelar.
            if (_modo == ModoFormulario.Nuevo)
            {
                CambiarModo(ModoFormulario.Consulta);
                MostrarProductoActual();
                return;
            }

            // Entramos en modificación.
            if (_modo == ModoFormulario.Consulta)
            {
                if (bindingSourceArticulos.Current is not ProductoDto)
                    return;

                CambiarModo(ModoFormulario.Modificar);

                textBoxDescripcion.Focus();
                return;
            }

            // Durante Modificar, funciona como Guardar.
            if (_modo != ModoFormulario.Modificar)
                return;

            if (!ValidarFormulario())
                return;

            try
            {
                var producto = CrearProductoDesdeFormulario();

                await _productoService.ModificarAsync(producto);

                int idProducto = producto.Id;

                CambiarModo(ModoFormulario.Consulta);

                await CargarProductosAsync(idProducto);

                MessageBox.Show(
                    "El artículo se modificó correctamente.",
                    "Artículo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo modificar el artículo.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (bindingSourceArticulos.Current is not ProductoDto producto)
                return;

            DialogResult resultado = MessageBox.Show(
                $"¿Desea eliminar el artículo '{producto.Nombre}'?",
                "Eliminar artículo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                int posicionAnterior =
                    bindingSourceArticulos.Position;

                await _productoService.EliminarAsync(producto.Id);

                await CargarProductosAsync();

                if (bindingSourceArticulos.Count > 0)
                {
                    bindingSourceArticulos.Position =
                        Math.Min(
                            posicionAnterior,
                            bindingSourceArticulos.Count - 1);
                }

                CambiarModo(ModoFormulario.Consulta);
                MostrarProductoActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar el artículo.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxCostoArt_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;

            RecalcularTodosDesdeRentabilidad();
        }

        private void textBoxRentaContado_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;

            RecalcularContadoDesdeRentabilidad();
        }

        private void textBoxContadoSIVA_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;

            RecalcularContadoDesdePrecio();
        }

        private void textBoxrentaReventa_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;

            RecalcularReventaDesdeRentabilidad();
        }

        private void textBoxReventaSIVA_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;
            RecalcularReventaDesdePrecio();
        }

        private void textBoxRentaCtaCte_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;

            RecalcularCtaCteDesdeRentabilidad();
        }

        private void textBoxCtaCteSIVA_Leave(object sender, EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                return;

            RecalcularCtaCteDesdePrecio();
        }

        private void textBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxCostoArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxRentaContado_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxContadoSIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxrentaReventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxReventaSIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxRentaCtaCte_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        private void textBoxCtaCteSIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoDecimal_KeyPress(sender, e);
        }

        //METODOS AUXILIARES PARA PRECIOS
        private decimal ObtenerCosto()
        {
            return ObtenerDecimal(textBoxCostoArt.Text);
        }
        private void RecalcularContadoDesdeRentabilidad()
        {
            decimal costo = ObtenerCosto();
            decimal rentabilidad = ObtenerDecimal(textBoxRentaContado.Text);

            decimal precio = ProductoCalculador.CalcularPrecio(
                costo,
                rentabilidad);

            textBoxContadoSIVA.Text = precio.ToString("0.00");

            ActualizarPreciosConIVA();
            ActualizarCategoria();
        }

        private void RecalcularContadoDesdePrecio()
        {
            decimal costo = ObtenerCosto();
            decimal precio = ObtenerDecimal(textBoxContadoSIVA.Text);

            decimal rentabilidad = ProductoCalculador.CalcularRentabilidad(
                costo,
                precio);

            textBoxRentaContado.Text = rentabilidad.ToString("0.00");

            ActualizarPreciosConIVA();
            ActualizarCategoria();
        }

        private void RecalcularReventaDesdeRentabilidad()
        {
            decimal costo = ObtenerCosto();
            decimal rentabilidad = ObtenerDecimal(textBoxrentaReventa.Text);

            decimal precio = ProductoCalculador.CalcularPrecio(
                costo,
                rentabilidad);

            textBoxReventaSIVA.Text = precio.ToString("0.00");

            ActualizarPreciosConIVA();
        }

        private void RecalcularReventaDesdePrecio()
        {
            decimal costo = ObtenerCosto();
            decimal precio = ObtenerDecimal(textBoxReventaSIVA.Text);

            decimal rentabilidad = ProductoCalculador.CalcularRentabilidad(
                costo,
                precio);

            textBoxrentaReventa.Text = rentabilidad.ToString("0.00");

            ActualizarPreciosConIVA();
        }

        private void RecalcularCtaCteDesdeRentabilidad()
        {
            decimal costo = ObtenerCosto();
            decimal rentabilidad = ObtenerDecimal(textBoxRentaCtaCte.Text);

            decimal precio = ProductoCalculador.CalcularPrecio(
                costo,
                rentabilidad);

            textBoxCtaCteSIVA.Text = precio.ToString("0.00");

            ActualizarPreciosConIVA();
        }

        private void RecalcularCtaCteDesdePrecio()
        {
            decimal costo = ObtenerCosto();
            decimal precio = ObtenerDecimal(textBoxCtaCteSIVA.Text);

            decimal rentabilidad = ProductoCalculador.CalcularRentabilidad(
                costo,
                precio);

            textBoxRentaCtaCte.Text = rentabilidad.ToString("0.00");

            ActualizarPreciosConIVA();
        }

        private void RecalcularTodosDesdeRentabilidad()
        {
            RecalcularContadoDesdeRentabilidad();
            RecalcularReventaDesdeRentabilidad();
            RecalcularCtaCteDesdeRentabilidad();
        }

        //AUX SOLO NUMEROS
        private void CampoDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) ||
                char.IsDigit(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (sender is TextBox textBox &&
                    !textBox.Text.Contains(',') &&
                    !textBox.Text.Contains('.'))
                {
                    e.KeyChar =
                        System.Globalization.CultureInfo
                            .CurrentCulture
                            .NumberFormat
                            .NumberDecimalSeparator[0];

                    return;
                }
            }

            // Permitimos negativos porque el stock legacy puede quedar negativo.
            if (e.KeyChar == '-')
            {
                if (sender is TextBox textBox &&
                    textBox.SelectionStart == 0 &&
                    !textBox.Text.Contains('-'))
                {
                    return;
                }
            }

            e.Handled = true;
        }

        //NUEVO PRODUCTO DESDE FORM
        private ProductoDto CrearProductoDesdeFormulario()
        {
            int id = 0;

            if (!string.IsNullOrWhiteSpace(textBoxCodigo.Text))
                int.TryParse(textBoxCodigo.Text, out id);

            return new ProductoDto
            {
                Id = id,

                Nombre = textBoxDescripcion.Text.Trim(),

                FamiliaId = ObtenerIdSeleccionado(comboBoxFamilia),
                MarcaId = ObtenerIdSeleccionado(comboBoxMarca),
                UnidadId = ObtenerIdSeleccionado(comboBoxUnidad),
                ProveedorId = ObtenerIdSeleccionado(comboBoxProveedor),

                Costo = ObtenerDecimal(textBoxCostoArt.Text),

                AlicuotaIVAId =
                    Convert.ToInt32(comboBoxAlicuota.SelectedValue),

                RentabilidadContado =
                    ObtenerDecimal(textBoxRentaContado.Text),

                PrecioContado =
                    ObtenerDecimal(textBoxContadoSIVA.Text),

                RentabilidadReventa =
                    ObtenerDecimal(textBoxrentaReventa.Text),

                PrecioReventa =
                    ObtenerDecimal(textBoxReventaSIVA.Text),

                RentabilidadCuentaCorriente =
                    ObtenerDecimal(textBoxRentaCtaCte.Text),

                PrecioCuentaCorriente =
                    ObtenerDecimal(textBoxCtaCteSIVA.Text),

                Stock =
                    ObtenerDecimal(textBoxStock.Text)
            };
        }

        private static int? ObtenerIdSeleccionado(ComboBox comboBox)
        {
            if (comboBox.SelectedValue == null)
                return null;

            if (comboBox.SelectedValue is int id)
                return id;

            return int.TryParse(
                comboBox.SelectedValue.ToString(),
                out int resultado)
                    ? resultado
                    : null;
        }

        //VALIDACION DE FORM
        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(textBoxDescripcion.Text))
            {
                MessageBox.Show(
                    "Debe ingresar la descripción del artículo.",
                    "Artículo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxDescripcion.Focus();
                return false;
            }

            if (comboBoxAlicuota.SelectedValue == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una alícuota de IVA.",
                    "Artículo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboBoxAlicuota.Focus();
                return false;
            }

            return true;
        }

        private void ArticulosForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            if (_modo == ModoFormulario.Consulta)
            {
                Close();
                return;
            }

            CambiarModo(ModoFormulario.Consulta);
            MostrarProductoActual();

            e.Handled = true;
        }

    }
}