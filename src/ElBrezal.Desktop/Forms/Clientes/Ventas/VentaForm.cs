using ElBrezal.Application.Calculations;
using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Interfaces.ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Desktop.Forms.Articulos.BusquedaArticulos;
using ElBrezal.Desktop.UI.Styles;
using ElBrezal.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Clientes.Ventas
{
    public partial class VentaForm : Form
    {
        private const int CuentaConsumidorFinal = 1;
        private const int CuentaClienteManual = 9999;

        private readonly IClienteService _clienteService;
        private readonly ISituacionImpositivaService _situacionImpositivaService;
        private readonly ICondicionVentaService _condicionVentaService;
        private readonly ITipoComprobanteService _tipoComprobanteService;
        private readonly IProductoService _productoService;
        private readonly IVendedorService _vendedorService;
        private readonly INumeracionComprobanteService _numeracionComprobanteService;

        private const int PuntoVenta = 1;
        private VendedorDto? _vendedorSeleccionado;

        private bool _inicializandoFormulario;

        private ClienteDto? _clienteSeleccionado;

        public VentaForm(IClienteService clienteService, ISituacionImpositivaService situacionImpositivaService, IProductoService productoService,
            ICondicionVentaService condicionVentaService, ITipoComprobanteService tipoComprobanteService, IVendedorService vendedorService, INumeracionComprobanteService numeracionComprobanteService)
        {
            InitializeComponent();

            _clienteService = clienteService;
            _situacionImpositivaService = situacionImpositivaService;
            _condicionVentaService = condicionVentaService;
            _tipoComprobanteService = tipoComprobanteService;
            _vendedorService = vendedorService;
            _productoService = productoService;
            _numeracionComprobanteService = numeracionComprobanteService;
        }

        private async void VentaForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaProductos();
            ConfigurarDatosCliente();

            _inicializandoFormulario = true;

            try
            {
                await InicializarVentaAsync();
            }
            finally
            {
                _inicializandoFormulario = false;
            }

            await CargarNumeracionComprobanteAsync();
        }


        #region //PREPARACION DE FORMULARIO DE VENTA, CARGA DE CLIENTE, CARGA DE PRODUCTOS, CALCULO DE TOTALES, ETC.
        private void ConfigurarGrillaProductos()
        {
            DataGridViewStyles.AplicarEstiloVenta(dataGridViewProductos);

            dataGridViewProductos.AllowUserToAddRows = false;
            dataGridViewProductos.AllowUserToDeleteRows = true;

            dataGridViewProductos.MultiSelect = false;
            dataGridViewProductos.ReadOnly = false;
            dataGridViewProductos.SelectionMode =
                DataGridViewSelectionMode.CellSelect;

            dataGridViewProductos.ScrollBars =
                ScrollBars.Vertical;

            DataGridViewTextBoxColumnCantidad.ReadOnly = false;
            DataGridViewTextBoxColumnArticulo.ReadOnly = false;
            DataGridViewTextBoxColumnDescripcion.ReadOnly = true;
            DataGridViewTextBoxColumnPrecio.ReadOnly = false;
            DataGridViewTextBoxColumnImporte.ReadOnly = true;

            DataGridViewTextBoxColumnPrecio.DefaultCellStyle.Format = "N2";
            DataGridViewTextBoxColumnImporte.DefaultCellStyle.Format = "N2";

            DataGridViewTextBoxColumnCantidad.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumnPrecio.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumnImporte.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumnCantidad.FillWeight = 10;
            DataGridViewTextBoxColumnArticulo.FillWeight = 26;
            DataGridViewTextBoxColumnDescripcion.FillWeight = 42;
            DataGridViewTextBoxColumnPrecio.FillWeight = 14;
            DataGridViewTextBoxColumnImporte.FillWeight = 16;

            // IMPORTANTE: ahora nosotros administramos las filas.
            AgregarFilaProducto();
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using var buscarClientesForm =
                new BuscarClientesForm(_clienteService);

            if (buscarClientesForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (buscarClientesForm.ClienteSeleccionado is null)
                return;

            MostrarCliente(buscarClientesForm.ClienteSeleccionado);
        }

        #endregion

        #region // Configuracion de groupBox Cliente
        private void ConfigurarDatosCliente()
        {
            textBoxFecha.ReadOnly = true;

            textBoxNombreCLiente.ReadOnly = true;
            textBoxDireccion.ReadOnly = true;
            textBoxTelCliente.ReadOnly = true;
            textBoxDNI.ReadOnly = true;
            textBoxZona.ReadOnly = true;
            comboBoxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCondicionVenta.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task CargarClienteAsync(int numeroCuenta)
        {
            if (numeroCuenta == CuentaClienteManual)
            {
                ActivarClienteManual();
                return;
            }

            var cliente =
                await _clienteService.ObtenerPorIdAsync(numeroCuenta);

            if (cliente is null)
            {
                MessageBox.Show(
                    $"No existe el cliente N° {numeroCuenta}.",
                    "Cliente no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNumCuenta.Focus();
                textBoxNumCuenta.SelectAll();

                return;
            }

            MostrarCliente(cliente);
        }

        private void MostrarCliente(ClienteDto cliente)
        {
            _clienteSeleccionado = cliente;

            DesactivarClienteManual();

            textBoxNumCuenta.Text = cliente.Id.ToString();
            textBoxNombreCLiente.Text = cliente.Nombre;
            textBoxDireccion.Text = cliente.Direccion ?? string.Empty;
            textBoxTelCliente.Text = cliente.Telefono ?? string.Empty;
            textBoxDNI.Text = cliente.DNI ?? string.Empty;

            textBoxZona.Text = cliente.Localidad;

            comboBoxTipo.SelectedValue = cliente.SituacionImpositivaId;

            if (cliente.VendedorId.HasValue)
            {
                _vendedorSeleccionado = new VendedorDto
                {
                    Id = cliente.VendedorId.Value,
                    Nombre = cliente.Vendedor ?? string.Empty
                };

                MostrarVendedor(_vendedorSeleccionado);
            }
            else
            {
                LimpiarVendedor();
            }

        }

        private void MostrarVendedor(VendedorDto vendedor)
        {
            _vendedorSeleccionado = vendedor;

            textBoxVendedor.Text =
                $"{vendedor.Id} - {vendedor.Nombre}";
        }


        private async Task CargarVendedorAsync(int vendedorId)
        {
            var vendedor =
                await _vendedorService.ObtenerPorIdAsync(vendedorId);

            if (vendedor is null)
            {
                MessageBox.Show(
                    $"No existe el vendedor N° {vendedorId}.",
                    "Vendedor no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxVendedor.Focus();
                textBoxVendedor.SelectAll();

                return;
            }

            MostrarVendedor(vendedor);
        }

        private void LimpiarVendedor()
        {
            _vendedorSeleccionado = null;
            textBoxVendedor.Clear();
        }


        private void ActivarClienteManual()
        {
            _clienteSeleccionado = null;

            LimpiarDatosCliente();

            textBoxNombreCLiente.ReadOnly = false;
            textBoxDireccion.ReadOnly = false;
            textBoxTelCliente.ReadOnly = false;
            textBoxDNI.ReadOnly = false;
            textBoxZona.ReadOnly = false;

            comboBoxTipo.Enabled = true;
            comboBoxCondicionVenta.Enabled = true;

            // Por defecto: Consumidor Final
            comboBoxTipo.SelectedValue = 2;
            comboBoxCondicionVenta.SelectedValue = 1;

            textBoxNombreCLiente.Focus();
        }

        private void DesactivarClienteManual()
        {
            textBoxNombreCLiente.ReadOnly = true;
            textBoxDireccion.ReadOnly = true;
            textBoxTelCliente.ReadOnly = true;
            textBoxDNI.ReadOnly = true;
            textBoxZona.ReadOnly = true;
        }

        private void LimpiarDatosCliente()
        {
            textBoxNombreCLiente.Clear();
            textBoxDireccion.Clear();
            textBoxTelCliente.Clear();
            textBoxDNI.Clear();
            textBoxZona.Clear();

            comboBoxTipo.SelectedIndex = -1;
            comboBoxCondicionVenta.SelectedIndex = -1;
        }
        private async void textBoxNumCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            if (!int.TryParse(textBoxNumCuenta.Text.Trim(), out int numeroCuenta))
            {
                MessageBox.Show(
                    "Ingrese un número de cuenta válido.",
                    "Cuenta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNumCuenta.Focus();
                textBoxNumCuenta.SelectAll();

                return;
            }

            await CargarClienteAsync(numeroCuenta);
        }

        private async Task CargarSituacionesImpositivasAsync()
        {
            var situaciones =
                await _situacionImpositivaService.ObtenerTodasAsync();

            comboBoxTipo.DataSource = situaciones;
            comboBoxTipo.DisplayMember = nameof(SituacionImpositivaDto.Nombre);
            comboBoxTipo.ValueMember = nameof(SituacionImpositivaDto.Id);

            comboBoxTipo.SelectedIndex = -1;
        }

        private async Task CargarCondicionesVentaAsync()
        {
            var condiciones =
                await _condicionVentaService.ObtenerTodasAsync();

            comboBoxCondicionVenta.DataSource = condiciones;
            comboBoxCondicionVenta.DisplayMember =
                nameof(CondicionVentaDto.Nombre);
            comboBoxCondicionVenta.ValueMember =
                nameof(CondicionVentaDto.Id);

            comboBoxCondicionVenta.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private async Task CargarTiposComprobanteAsync()
        {
            var tipos =
                await _tipoComprobanteService.ObtenerTodosAsync();

            comboBoxTipoComprobante.DataSource = tipos;
            comboBoxTipoComprobante.DisplayMember =
                nameof(TipoComprobanteDto.Nombre);
            comboBoxTipoComprobante.ValueMember =
                nameof(TipoComprobanteDto.Id);

            comboBoxTipoComprobante.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private async Task CargarNumeracionComprobanteAsync()
        {
            if (comboBoxTipoComprobante.SelectedValue is null)
            {
                maskedTextBoxNumeroComprob.Clear();
                return;
            }

            if (!int.TryParse(
                comboBoxTipoComprobante.SelectedValue.ToString(),
                out int tipoComprobanteId))
            {
                maskedTextBoxNumeroComprob.Clear();
                return;
            }

            var numeracion =
                await _numeracionComprobanteService.ObtenerPorTipoYPuntoVentaAsync(
                    tipoComprobanteId,
                    PuntoVenta);

            if (numeracion is null)
            {
                maskedTextBoxNumeroComprob.Clear();
                return;
            }

            maskedTextBoxNumeroComprob.Text =
                numeracion.ProximoNumeroFormateado;
        }

        #endregion

        #region // CARGA DE PRODUCTOS, CALCULO DE TOTALES, ETC.
        private async Task InicializarVentaAsync()
        {
            textBoxFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            await CargarSituacionesImpositivasAsync();
            await CargarCondicionesVentaAsync();
            await CargarTiposComprobanteAsync();

            textBoxNumCuenta.Text =
                CuentaConsumidorFinal.ToString();

            await CargarClienteAsync(CuentaConsumidorFinal);
        }

        private void CargarProductoEnFila(DataGridViewRow fila, ProductoDto producto)
        {
            fila.Cells[DataGridViewTextBoxColumnCantidad.Name].Value = 1;

            fila.Cells[DataGridViewTextBoxColumnArticulo.Name].Value =
                producto.Id;

            fila.Cells[DataGridViewTextBoxColumnDescripcion.Name].Value =
                producto.Nombre.ToUpperInvariant();

            fila.Cells[DataGridViewTextBoxColumnPrecio.Name].Value =
                producto.PrecioContado;


            RecalcularFila(fila);

            IrASiguienteFilaProducto(fila.Index);
        }

        private void IrASiguienteFilaProducto(int filaActual)
        {
            int siguienteFila = filaActual + 1;

            if (siguienteFila >= dataGridViewProductos.Rows.Count)
            {
                AgregarFilaProducto();
            }

            dataGridViewProductos.CurrentCell =
                dataGridViewProductos.Rows[siguienteFila]
                    .Cells[DataGridViewTextBoxColumnArticulo.Name];

            dataGridViewProductos.Focus();
        }

        private void AbrirBuscadorProductos()
        {
            if (dataGridViewProductos.CurrentRow is null)
                return;

            var fila = dataGridViewProductos.CurrentRow;

            using var buscarProductosForm =
                new BuscarProductosForm(_productoService);

            if (buscarProductosForm.ShowDialog(this) != DialogResult.OK)
                return;

            if (buscarProductosForm.ProductoSeleccionado is null)
                return;

            CargarProductoEnFila(fila, buscarProductosForm.ProductoSeleccionado);
        }

        private async void dataGridViewProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridViewProductos.CurrentCell?.OwningColumn
                != DataGridViewTextBoxColumnArticulo)
                return;

            if (e.KeyCode == Keys.F1)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AbrirBuscadorProductos();
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                dataGridViewProductos.EndEdit();

                await CargarProductoIngresadoAsync();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();

                return true;
            }

            if (keyData == Keys.Tab &&
                dataGridViewProductos.ContainsFocus &&
                dataGridViewProductos.CurrentCell?.OwningColumn
                    == DataGridViewTextBoxColumnArticulo)
            {
                ProcesarArticuloConTab();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ActualizarAlicuotaCliente()
        {
            if (comboBoxTipo.SelectedItem is SituacionImpositivaDto situacion)
            {
                lblAlicuotaProcentaje.Text =
                    $"{situacion.Porce:N2}%";
            }
            else
            {
                lblAlicuotaProcentaje.Text = "0,00%";
            }
        }

        private async void ProcesarArticuloConTab()
        {
            dataGridViewProductos.EndEdit();

            await CargarProductoIngresadoAsync();
        }

        private async Task<bool> CargarProductoIngresadoAsync()
        {
            if (dataGridViewProductos.CurrentRow is null)
                return false;

            var fila = dataGridViewProductos.CurrentRow;

            var valor = fila
                .Cells[DataGridViewTextBoxColumnArticulo.Name]
                .Value?
                .ToString()
                ?.Trim();

            if (!int.TryParse(valor, out int productoId))
            {
                MessageBox.Show(
                    "Ingrese un número de artículo válido.",
                    "Artículo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                PosicionarEnArticulo(fila);

                return false;
            }

            var producto = await _productoService.ObtenerPorIdAsync(productoId);

            if (producto is null)
            {
                MessageBox.Show(
                    $"No existe el artículo N° {productoId}.",
                    "Artículo no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                PosicionarEnArticulo(fila);

                return false;
            }

            CargarProductoEnFila(fila, producto);

            return true;
        }

        private void PosicionarEnArticulo(DataGridViewRow fila)
        {
            dataGridViewProductos.CurrentCell =
                fila.Cells[DataGridViewTextBoxColumnArticulo.Name];

            dataGridViewProductos.Focus();

            dataGridViewProductos.BeginEdit(true);
        }

        private void AgregarFilaProducto()
        {
            int indice = dataGridViewProductos.Rows.Add();

            var fila = dataGridViewProductos.Rows[indice];

        }

        private void RecalcularFila(DataGridViewRow fila)
        {
            decimal cantidad = ObtenerDecimalCelda(fila, DataGridViewTextBoxColumnCantidad.Name);

            decimal precio = ObtenerDecimalCelda(fila, DataGridViewTextBoxColumnPrecio.Name);

            decimal importe = OperacionComercialCalculations.CalcularImporte(cantidad, precio);

            fila.Cells[DataGridViewTextBoxColumnImporte.Name].Value = importe;

            RecalcularTotales();
        }

        private void RecalcularTotales()
        {
            decimal subtotal = 0m;
            int cantidadArticulos = 0;

            foreach (DataGridViewRow fila in dataGridViewProductos.Rows)
            {
                var articulo = fila
                    .Cells[DataGridViewTextBoxColumnArticulo.Name]
                    .Value;

                if (articulo is null ||
                    string.IsNullOrWhiteSpace(articulo.ToString()))
                {
                    continue;
                }

                subtotal += ObtenerDecimalCelda(
                    fila,
                    DataGridViewTextBoxColumnImporte.Name);

                cantidadArticulos++;
            }

            decimal porcentajeVariacion = 0m;

            decimal.TryParse(textBoxVariacionVenta.Text, out porcentajeVariacion);

            decimal montoVariacion = OperacionComercialCalculations.CalcularMontoVariacion(subtotal, porcentajeVariacion);

            decimal total = OperacionComercialCalculations.CalcularTotal(subtotal, montoVariacion);

            lblArticulosCantidad.Text = cantidadArticulos.ToString();

            lblSubTotal.Text = subtotal.ToString("N2");

            lblVariacion.Text = montoVariacion.ToString("N2");

            lblMontoTotal.Text = total.ToString("N2");
        }

        private decimal ObtenerDecimalCelda(DataGridViewRow fila, string nombreColumna)
        {
            var valor = fila.Cells[nombreColumna].Value;

            if (valor is null)
                return 0m;

            return decimal.TryParse(
                valor.ToString(),
                out decimal resultado)
                    ? resultado
                    : 0m;
        }

        #endregion


        private void textBoxNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private async void textBoxVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.SuppressKeyPress = true;

                // Próximamente:
                // AbrirBuscarVendedores();

                return;
            }

            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            if (!int.TryParse(textBoxVendedor.Text.Trim(), out int vendedorId))
            {
                MessageBox.Show(
                    "Ingrese un número de vendedor válido.",
                    "Vendedor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxVendedor.Focus();
                textBoxVendedor.SelectAll();

                return;
            }

            await CargarVendedorAsync(vendedorId);
        }


        private void textBoxVendedor_Enter(object sender, EventArgs e)
        {
            textBoxVendedor.SelectAll();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnSalir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void dataGridViewProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var columna = dataGridViewProductos.Columns[e.ColumnIndex];

            if (columna != DataGridViewTextBoxColumnCantidad &&
                columna != DataGridViewTextBoxColumnPrecio)
            {
                return;
            }

            RecalcularFila(dataGridViewProductos.Rows[e.RowIndex]);
        }

        private void textBoxVariacionVenta_TextChanged(object sender, EventArgs e)
        {
            RecalcularTotales();
        }

        private void comboBoxTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            ActualizarAlicuotaCliente();
        }

        private async void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            await NuevaVentaAsync();
        }

        private async Task NuevaVentaAsync()
        {
            // Datos generales
            textBoxFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            await CargarNumeracionComprobanteAsync();
            textBoxVariacionVenta.Clear();

            // Si este es el TextBox de observaciones:
            textBoxObservacion.Clear();

            // Productos
            dataGridViewProductos.Rows.Clear();
            AgregarFilaProducto();

            // Totales
            lblArticulosCantidad.Text = "0";
            lblSubTotal.Text = 0m.ToString("N2");
            lblVariacion.Text = 0m.ToString("N2");
            lblMontoTotal.Text = 0m.ToString("N2");

            // Cliente por defecto
            textBoxNumCuenta.Text = CuentaConsumidorFinal.ToString();

            await CargarClienteAsync(CuentaConsumidorFinal);

            // Posicionar para comenzar la nueva venta
            dataGridViewProductos.CurrentCell =
                dataGridViewProductos.Rows[0]
                    .Cells[DataGridViewTextBoxColumnArticulo.Name];

            dataGridViewProductos.Focus();
        }

        private async void comboBoxTipoComprobante_SelectedValueChanged( object sender, EventArgs e)
        {
            if (_inicializandoFormulario)
                return;

            await CargarNumeracionComprobanteAsync();
        }
        
    }
}

