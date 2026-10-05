using ElBrezal.Application.Calculations;
using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Interfaces.ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Application.Validators;
using ElBrezal.Desktop.Forms.Articulos.BusquedaArticulos;
using ElBrezal.Desktop.Forms.Tablas.Localidades;
using ElBrezal.Desktop.UI.Styles;
using ElBrezal.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ElBrezal.Desktop.Helpers;

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
        private readonly ILocalidadService _localidadService;
        private readonly IComprobanteService _comprobanteService;

        private const int PuntoVenta = 1;
        private VendedorDto? _vendedorSeleccionado;

        private int? _presupuestoAsociadoId;
        private bool _inicializandoFormulario;
        private bool _guardandoVenta;
        private ClienteDto? _clienteSeleccionado;
        private LocalidadDto? _localidadSeleccionada;

        public VentaForm(IClienteService clienteService, ISituacionImpositivaService situacionImpositivaService, IProductoService productoService,
            ICondicionVentaService condicionVentaService, ITipoComprobanteService tipoComprobanteService, IVendedorService vendedorService,
            INumeracionComprobanteService numeracionComprobanteService, ILocalidadService localidadService, IComprobanteService comprobanteService)
        {

            InitializeComponent();

            _clienteService = clienteService;
            _situacionImpositivaService = situacionImpositivaService;
            _condicionVentaService = condicionVentaService;
            _tipoComprobanteService = tipoComprobanteService;
            _vendedorService = vendedorService;
            _productoService = productoService;
            _numeracionComprobanteService = numeracionComprobanteService;
            _localidadService = localidadService;
            _comprobanteService = comprobanteService;
        }

        private async void VentaForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaProductos();
            ConfigurarDatosCliente();
            textBoxCUIT.ReadOnly = true;

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
            DataGridViewTextBoxColumnArticulo.FillWeight = 15;
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
                await ActivarClienteManualAsync();
                return;
            }
            var cliente = await _clienteService.ObtenerPorIdAsync(numeroCuenta);

            if (cliente is null)
            {
                MessageBox.Show($"No existe el cliente N° {numeroCuenta}.", "Cliente no encontrado",
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
            textBoxCUIT.Text = cliente.CUIT ?? string.Empty;

            _localidadSeleccionada = new LocalidadDto
            {
                Id = cliente.LocalidadId,
                Nombre = cliente.Localidad ?? string.Empty
            };

            MostrarLocalidad(_localidadSeleccionada);

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

        private void MostrarLocalidad(LocalidadDto localidad)
        {
            _localidadSeleccionada = localidad;

            textBoxZona.Text =
                $"{localidad.Id} - {localidad.Nombre}";
        }

        private async Task ActivarClienteManualAsync()
        {
            _clienteSeleccionado = null;

            LimpiarDatosCliente();

            textBoxNombreCLiente.ReadOnly = false;
            textBoxDireccion.ReadOnly = false;
            textBoxTelCliente.ReadOnly = false;
            textBoxDNI.ReadOnly = false;
            textBoxCUIT.ReadOnly = false;
            textBoxZona.ReadOnly = false;

            comboBoxTipo.Enabled = true;
            comboBoxCondicionVenta.Enabled = true;

            comboBoxTipo.SelectedValue = 2;
            comboBoxCondicionVenta.SelectedValue = 1;

            await CargarLocalidadAsync(1);
            await CargarVendedorAsync(1);

            textBoxNombreCLiente.Focus();
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

        private void LimpiarPresupuestoAsociado()
        {
            _presupuestoAsociadoId = null;
            maskedTextBoxPresupAsociado.Clear();
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
            textBoxCUIT.Clear();
            textBoxZona.Clear();

            _localidadSeleccionada = null;

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

        private async void textBoxZona_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.SuppressKeyPress = true;

                AbrirBuscarLocalidades();

                return;
            }

            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            var texto = textBoxZona.Text
                .Split('-')[0]
                .Trim();

            if (!int.TryParse(texto, out int localidadId))
            {
                MessageBox.Show(
                    "Ingrese un número de localidad válido.",
                    "Localidad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxZona.Focus();
                textBoxZona.SelectAll();

                return;
            }

            await CargarLocalidadAsync(localidadId);
        }

        private void AbrirBuscarLocalidades()
        {
            using var form = new BuscarLocalidadesForm(_localidadService);

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            if (form.LocalidadSeleccionada is null)
                return;

            MostrarLocalidad(form.LocalidadSeleccionada);
        }

        private async Task CargarLocalidadAsync(int localidadId)
        {
            var localidad =
                await _localidadService.ObtenerPorIdAsync(localidadId);

            if (localidad is null)
            {
                MessageBox.Show(
                    $"No existe la localidad N° {localidadId}.",
                    "Localidad no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxZona.Focus();
                textBoxZona.SelectAll();

                return;
            }

            MostrarLocalidad(localidad);
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
            if (VerificarProductoYaCargado(producto.Id, fila))
                return;

            var cantidad =
                ObtenerDecimalCelda(
                    fila,
                    DataGridViewTextBoxColumnCantidad.Name);

            if (cantidad <= 0)
                cantidad = 1;

            fila.Cells[DataGridViewTextBoxColumnCantidad.Name].Value =
                cantidad;

            fila.Cells[DataGridViewTextBoxColumnArticulo.Name].Value =
                producto.Id;

            fila.Cells[DataGridViewTextBoxColumnDescripcion.Name].Value =
                producto.Nombre.ToUpperInvariant();

            fila.Cells[DataGridViewTextBoxColumnPrecio.Name].Value =
                producto.PrecioContado;

            RecalcularFila(fila);

            IrASiguienteFilaProducto(fila.Index);
        }

        private bool VerificarProductoYaCargado(int productoId, DataGridViewRow filaActual)
        {
            var filaExistente =
                OperacionProductosGridHelper.BuscarFilaProducto(
                    dataGridViewProductos,
                    DataGridViewTextBoxColumnArticulo,
                    productoId,
                    filaActual);

            if (filaExistente is null)
                return false;

            MessageBox.Show(
                "El producto ya se encuentra cargado en la venta.\n\n" +
                "Modifique la cantidad en el renglón existente.",
                "Producto ya cargado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            OperacionProductosGridHelper.LimpiarFila(
                filaActual,
                DataGridViewTextBoxColumnCantidad,
                DataGridViewTextBoxColumnArticulo,
                DataGridViewTextBoxColumnDescripcion,
                DataGridViewTextBoxColumnPrecio,
                DataGridViewTextBoxColumnImporte);

            RecalcularTotales();

            OperacionProductosGridHelper.PosicionarEnCantidad(
                dataGridViewProductos,
                filaExistente,
                DataGridViewTextBoxColumnCantidad);

            return true;
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
                    .Cells[DataGridViewTextBoxColumnCantidad.Name];

            dataGridViewProductos.Focus();
            dataGridViewProductos.BeginEdit(true);
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

        private async void dataGridViewProductos_KeyDown(
    object sender,
    KeyEventArgs e)
        {
            if (dataGridViewProductos.CurrentCell is null)
                return;

            var columnaActual =
                dataGridViewProductos.CurrentCell.OwningColumn;

            // CANTIDAD -> ENTER lleva a ARTÍCULO
            if (columnaActual == DataGridViewTextBoxColumnCantidad &&
                e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                dataGridViewProductos.EndEdit();

                var fila = dataGridViewProductos.CurrentRow;

                if (fila is null)
                    return;

                dataGridViewProductos.CurrentCell =
                    fila.Cells[DataGridViewTextBoxColumnArticulo.Name];

                dataGridViewProductos.BeginEdit(true);

                return;
            }

            // ARTÍCULO -> F1 abre buscador
            if (columnaActual == DataGridViewTextBoxColumnArticulo &&
                e.KeyCode == Keys.F1)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AbrirBuscadorProductos();

                return;
            }

            // ARTÍCULO -> ENTER carga producto
            if (columnaActual == DataGridViewTextBoxColumnArticulo &&
                e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                dataGridViewProductos.EndEdit();

                await CargarProductoIngresadoAsync();

                return;
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

            if (keyData == Keys.F11)
            {
                _ = GuardarVentaAsync();
                return true;
            }

            if (keyData == Keys.Tab &&
                dataGridViewProductos.ContainsFocus)
            {
                var columnaActual =
                    dataGridViewProductos.CurrentCell?.OwningColumn;

                // CANTIDAD -> TAB -> ARTÍCULO
                if (columnaActual == DataGridViewTextBoxColumnCantidad)
                {
                    dataGridViewProductos.EndEdit();

                    var fila = dataGridViewProductos.CurrentRow;

                    if (fila is null)
                        return true;

                    dataGridViewProductos.CurrentCell =
                        fila.Cells[DataGridViewTextBoxColumnArticulo.Name];

                    dataGridViewProductos.BeginEdit(true);

                    return true;
                }

                // ARTÍCULO -> TAB -> CARGAR PRODUCTO
                if (columnaActual == DataGridViewTextBoxColumnArticulo)
                {
                    ProcesarArticuloConTab();

                    return true;
                }
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
            textBoxCUIT.Clear();

            // Si este es el TextBox de observaciones:
            textBoxObservacion.Clear();

            // Presupuesto asociado
            LimpiarPresupuestoAsociado();

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

        private async void comboBoxTipoComprobante_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_inicializandoFormulario)
                return;

            await CargarNumeracionComprobanteAsync();
        }

        private void textBoxCUIT_Leave(object sender, EventArgs e)
        {
            ValidarCuitIngresado();
        }
        private bool ValidarCuitIngresado()
        {
            var cuit = ObtenerCuit();

            if (string.IsNullOrWhiteSpace(cuit))
                return true;

            if (CuitValidator.Validar(cuit))
                return true;

            MessageBox.Show(
                "El CUIT ingresado no es válido.",
                "Verificación de CUIT",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            textBoxCUIT.Focus();
            textBoxCUIT.SelectAll();

            return false;
        }

        private string? ObtenerCuit()
        {
            var formatoActual = textBoxCUIT.TextMaskFormat;

            textBoxCUIT.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            string cuitSinFormato = textBoxCUIT.Text;

            textBoxCUIT.TextMaskFormat = formatoActual;

            if (string.IsNullOrWhiteSpace(cuitSinFormato))
                return null;

            if (cuitSinFormato.Length != 11)
                return textBoxCUIT.Text.Trim();

            return
                $"{cuitSinFormato[..2]}-" +
                $"{cuitSinFormato.Substring(2, 8)}-" +
                $"{cuitSinFormato[10]}";
        }

        private bool ValidarVenta()
        {
            if (comboBoxTipoComprobante.SelectedValue is not int tipoComprobanteId ||
                tipoComprobanteId <= 0)
            {
                MessageBox.Show(
                    "Seleccione un tipo de comprobante.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboBoxTipoComprobante.Focus();
                return false;
            }

            if (_clienteSeleccionado is null &&
                textBoxNumCuenta.Text.Trim() != CuentaClienteManual.ToString())
            {
                MessageBox.Show(
                    "Seleccione un cliente válido.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNumCuenta.Focus();
                textBoxNumCuenta.SelectAll();

                return false;
            }

            if (_vendedorSeleccionado is null)
            {
                MessageBox.Show(
                    "Seleccione un vendedor.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxVendedor.Focus();
                return false;
            }

            if (comboBoxCondicionVenta.SelectedValue is not int condicionVentaId ||
                condicionVentaId <= 0)
            {
                MessageBox.Show(
                    "Seleccione una condición de venta.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboBoxCondicionVenta.Focus();
                return false;
            }

            if (comboBoxTipo.SelectedValue is not int situacionImpositivaId ||
                situacionImpositivaId <= 0)
            {
                MessageBox.Show(
                    "Seleccione una situación impositiva.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                comboBoxTipo.Focus();
                return false;
            }

            var tieneArticulos = dataGridViewProductos.Rows
                .Cast<DataGridViewRow>()
                .Any(row =>
                    !row.IsNewRow &&
                    int.TryParse(
                        row.Cells[DataGridViewTextBoxColumnArticulo.Name]
                            .Value?.ToString(),
                        out var productoId) &&
                    productoId > 0);

            if (!tieneArticulos)
            {
                MessageBox.Show(
                    "Debe ingresar al menos un producto.",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dataGridViewProductos.Focus();
                return false;
            }

            if (textBoxNumCuenta.Text.Trim() ==
                CuentaClienteManual.ToString())
            {
                if (string.IsNullOrWhiteSpace(textBoxNombreCLiente.Text))
                {
                    MessageBox.Show(
                        "Ingrese el nombre del cliente.",
                        "Cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxNombreCLiente.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
                {
                    MessageBox.Show(
                        "Ingrese la dirección del cliente.",
                        "Cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxDireccion.Focus();
                    return false;
                }

                var dni = textBoxDNI.Text.Trim();
                var cuit = ObtenerCuit();

                if (string.IsNullOrWhiteSpace(dni) &&
                    string.IsNullOrWhiteSpace(cuit))
                {
                    MessageBox.Show(
                        "Ingrese DNI o CUIT del cliente.",
                        "Cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxDNI.Focus();
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(cuit) &&
                    !CuitValidator.Validar(cuit))
                {
                    MessageBox.Show(
                        "El CUIT ingresado no es válido.",
                        "CUIT",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxCUIT.Focus();
                    return false;
                }

                if (_localidadSeleccionada is null)
                {
                    MessageBox.Show(
                        "Seleccione una localidad.",
                        "Cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    textBoxZona.Focus();
                    return false;
                }
            }

            return true;
        }

        private CrearComprobanteDto ConstruirComprobante()
        {
            var esClienteRapido =
                textBoxNumCuenta.Text.Trim() ==
                CuentaClienteManual.ToString();

            var dto = new CrearComprobanteDto
            {
                TipoComprobanteId =
                    Convert.ToInt32(comboBoxTipoComprobante.SelectedValue),

                PuntoVenta = PuntoVenta,
                Fecha = DateTime.Now,

                ClienteId = esClienteRapido
                    ? null
                    : _clienteSeleccionado!.Id,

                VendedorId = _vendedorSeleccionado!.Id,

                CondicionVentaId =
                    Convert.ToInt32(comboBoxCondicionVenta.SelectedValue),

                SituacionImpositivaId =
                    Convert.ToInt32(comboBoxTipo.SelectedValue),

                ComprobanteOrigenId = _presupuestoAsociadoId,

                PorcentajeVariacion = decimal.TryParse(textBoxVariacionVenta.Text, out var porcentajeVariacion) ? porcentajeVariacion : 0m,

                Observacion = string.IsNullOrWhiteSpace(textBoxObservacion.Text)
                    ? null
                    : textBoxObservacion.Text.Trim()
            };

            if (esClienteRapido)
            {
                var cuit = ObtenerCuit();

                dto.ClienteRapido = new ClienteRapidoDto
                {
                    Nombre = textBoxNombreCLiente.Text.Trim(),

                    DNI = string.IsNullOrWhiteSpace(textBoxDNI.Text)
                        ? null
                        : textBoxDNI.Text.Trim(),

                    CUIT = string.IsNullOrWhiteSpace(cuit)
                        ? null
                        : cuit,

                    Direccion = string.IsNullOrWhiteSpace(textBoxDireccion.Text)
                        ? null
                        : textBoxDireccion.Text.Trim(),

                    Telefono = string.IsNullOrWhiteSpace(textBoxTelCliente.Text)
                        ? null
                        : textBoxTelCliente.Text.Trim(),

                    LocalidadId = _localidadSeleccionada!.Id,

                    SituacionImpositivaId =
                        Convert.ToInt32(comboBoxTipo.SelectedValue),

                    EstadoCuentaId = 1,

                    VendedorId = _vendedorSeleccionado!.Id
                };
            }
            foreach (DataGridViewRow row in dataGridViewProductos.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (!int.TryParse(
                        row.Cells["DataGridViewTextBoxColumnArticulo"].Value?.ToString(),
                        out var productoId) ||
                    productoId <= 0)
                {
                    continue;
                }

                if (!decimal.TryParse(
                        row.Cells["DataGridViewTextBoxColumnCantidad"].Value?.ToString(),
                        out var cantidad))
                {
                    cantidad = 0m;
                }

                if (!decimal.TryParse(
                        row.Cells["DataGridViewTextBoxColumnPrecio"].Value?.ToString(),
                        out var precio))
                {
                    precio = 0m;
                }

                var descripcion =
                    row.Cells["DataGridViewTextBoxColumnDescripcion"].Value?.ToString()
                    ?? string.Empty;

                var importe =
                    OperacionComercialCalculations.CalcularImporte(
                        cantidad,
                        precio);

                dto.Detalles.Add(new ComprobanteDetalleDto
                {
                    ProductoId = productoId,
                    Descripcion = descripcion,
                    Cantidad = cantidad,
                    PrecioUnitario = precio,
                    Importe = importe
                });
            }

            dto.Subtotal = dto.Detalles.Sum(x => x.Importe);

            dto.MontoVariacion =
                OperacionComercialCalculations.CalcularMontoVariacion(
                    dto.Subtotal,
                    dto.PorcentajeVariacion);

            dto.Total =
                OperacionComercialCalculations.CalcularTotal(
                    dto.Subtotal,
                    dto.MontoVariacion);

            return dto;
        }

        private async Task GuardarVentaAsync()
        {
            if (_guardandoVenta)
                return;

            if (!ValidarVenta())
                return;

            try
            {
                _guardandoVenta = true;

                btnConfirmar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var dto = ConstruirComprobante();

                var resultado =
                    await _comprobanteService.CrearAsync(dto);

                MessageBox.Show(
                    $"Venta guardada correctamente.\n\n" +
                    $"Número: {resultado.PuntoVenta:0000}-{resultado.Numero:000000}",
                    "Venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                await NuevaVentaAsync();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo guardar la venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al guardar la venta.\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                _guardandoVenta = false;

                btnConfirmar.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            await GuardarVentaAsync();
        }

        private bool TryObtenerNumeroPresupuesto(out int puntoVenta,out int numero)
        {
            puntoVenta = 0;
            numero = 0;

            var valor = ObtenerNumeroPresupuestoIngresado();

            if (string.IsNullOrWhiteSpace(valor))
                return false;

            // Máscara esperada: 0000-000000
            // Sin literales: 0001000125
            if (valor.Length != 10)
                return false;

            return
                int.TryParse(valor[..4], out puntoVenta) &&
                int.TryParse(valor[4..], out numero) &&
                puntoVenta > 0 &&
                numero > 0;
        }

        private string ObtenerNumeroPresupuestoIngresado()
        {
            var formatoActual =
                maskedTextBoxPresupAsociado.TextMaskFormat;

            maskedTextBoxPresupAsociado.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            var valor = maskedTextBoxPresupAsociado.Text;

            maskedTextBoxPresupAsociado.TextMaskFormat =
                formatoActual;

            return valor;
        }
        private async Task CargarPresupuestoAsociadoAsync()
        {
            _presupuestoAsociadoId = null;

            var valor = ObtenerNumeroPresupuestoIngresado();

            // Presupuesto opcional.
            if (string.IsNullOrWhiteSpace(valor))
                return;

            if (!TryObtenerNumeroPresupuesto(
                    out var puntoVenta,
                    out var numero))
            {
                MessageBox.Show(
                    "El número de presupuesto ingresado no es válido.",
                    "Presupuesto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                maskedTextBoxPresupAsociado.Focus();
                maskedTextBoxPresupAsociado.SelectAll();

                return;
            }

            var presupuesto =
                await _comprobanteService.ObtenerPresupuestoAsync(
                    puntoVenta,
                    numero);

            if (presupuesto is null)
            {
                MessageBox.Show(
                    "No se encontró el presupuesto ingresado.",
                    "Presupuesto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                maskedTextBoxPresupAsociado.Focus();
                maskedTextBoxPresupAsociado.SelectAll();

                return;
            }

            // Asociación real que después persistiremos.
            _presupuestoAsociadoId = presupuesto.Id;

            // Cargar cliente original del presupuesto.
            textBoxNumCuenta.Text =
                presupuesto.ClienteId.ToString();

            // Variación original del presupuesto
            textBoxVariacionVenta.Text =
                presupuesto.PorcentajeVariacion.ToString("N2");

            await CargarClienteAsync(
                presupuesto.ClienteId);

            // Cargar artículos y precios históricos.
            CargarProductosPresupuesto(
                presupuesto);
        }

        private void CargarProductosPresupuesto(ComprobanteDto presupuesto)
        {
            dataGridViewProductos.Rows.Clear();

            foreach (var detalle in presupuesto.Detalles)
            {
                var indiceFila =
                    dataGridViewProductos.Rows.Add();

                var fila =
                    dataGridViewProductos.Rows[indiceFila];

                fila.Cells[DataGridViewTextBoxColumnCantidad.Name].Value =
                    detalle.Cantidad;

                fila.Cells[DataGridViewTextBoxColumnArticulo.Name].Value =
                    detalle.ProductoId;

                fila.Cells[DataGridViewTextBoxColumnDescripcion.Name].Value =
                    detalle.Descripcion;

                fila.Cells[DataGridViewTextBoxColumnPrecio.Name].Value =
                    detalle.PrecioUnitario;

                fila.Cells[DataGridViewTextBoxColumnImporte.Name].Value =
                    detalle.Importe;
            }

            AgregarFilaProducto();

            RecalcularTotales();
        }

        private async void maskedTextBoxPresupAsociado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            await CargarPresupuestoAsociadoAsync();
        }
    }

}