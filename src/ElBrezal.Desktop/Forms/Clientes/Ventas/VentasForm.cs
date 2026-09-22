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

namespace ElBrezal.Desktop.Forms.Clientes.Ventas
{
    public partial class VentaForm : Form
    {
        private const int CuentaConsumidorFinal = 1;
        private const int CuentaClienteManual = 9999;

        private readonly IClienteService _clienteService;
        private readonly ISituacionImpositivaService _situacionImpositivaService;

        private ClienteDto? _clienteSeleccionado;

        public VentaForm(IClienteService clienteService, ISituacionImpositivaService situacionImpositivaService)
        {
            InitializeComponent();

            _clienteService = clienteService;
            _situacionImpositivaService = situacionImpositivaService;
        }

        private async void VentaForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaProductos();
            ConfigurarDatosCliente();

            await InicializarVentaAsync();
        }


        #region //PREPARACION DE FORMULARIO DE VENTA, CARGA DE CLIENTE, CARGA DE PRODUCTOS, CALCULO DE TOTALES, ETC.
        private void ConfigurarGrillaProductos()
        {
            // =========================================================
            // ESTILO VISUAL
            // =========================================================

            DataGridViewStyles.AplicarEstiloVenta(dataGridViewProductos);

            // =========================================================
            // COMPORTAMIENTO ESPECÍFICO DE VENTAS
            // =========================================================

            dataGridViewProductos.AutoGenerateColumns = false;
            dataGridViewProductos.AllowUserToAddRows = true;
            dataGridViewProductos.AllowUserToDeleteRows = true;
            dataGridViewProductos.MultiSelect = false;
            dataGridViewProductos.ReadOnly = false;

            dataGridViewProductos.SelectionMode =
                DataGridViewSelectionMode.CellSelect;

            dataGridViewProductos.ScrollBars =
                ScrollBars.Vertical;

            // =========================================================
            // COLUMNAS EDITABLES
            // =========================================================

            DataGridViewTextBoxColumnCantidad.ReadOnly = false;
            DataGridViewTextBoxColumnArticulo.ReadOnly = false;
            DataGridViewTextBoxColumnPrecio.ReadOnly = false;
            DataGridViewTextBoxColumnDescuento.ReadOnly = false;

            // =========================================================
            // COLUMNAS INFORMATIVAS / CALCULADAS
            // =========================================================

            DataGridViewTextBoxColumnDescripcion.ReadOnly = true;
            DataGridViewTextBoxColumnImporte.ReadOnly = true;

            // =========================================================
            // FORMATOS
            // =========================================================

            DataGridViewTextBoxColumnCantidad.DefaultCellStyle.Format = "N2";
            DataGridViewTextBoxColumnPrecio.DefaultCellStyle.Format = "N2";
            DataGridViewTextBoxColumnDescuento.DefaultCellStyle.Format = "N2";
            DataGridViewTextBoxColumnImporte.DefaultCellStyle.Format = "N2";

            DataGridViewTextBoxColumnCantidad.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumnPrecio.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumnDescuento.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxColumnImporte.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            // =========================================================
            // DISTRIBUCIÓN
            // =========================================================

            DataGridViewTextBoxColumnCantidad.FillWeight = 10;
            DataGridViewTextBoxColumnArticulo.FillWeight = 16;
            DataGridViewTextBoxColumnDescripcion.FillWeight = 42;
            DataGridViewTextBoxColumnPrecio.FillWeight = 14;
            DataGridViewTextBoxColumnDescuento.FillWeight = 10;
            DataGridViewTextBoxColumnImporte.FillWeight = 16;


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

            // Por defecto: Consumidor Final
            comboBoxTipo.SelectedValue = 2;

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
        #endregion

        #region // CARGA DE PRODUCTOS, CALCULO DE TOTALES, ETC.
        private async Task InicializarVentaAsync()
        {
            textBoxFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            await CargarSituacionesImpositivasAsync();

            textBoxNumCuenta.Text =
                CuentaConsumidorFinal.ToString();

            await CargarClienteAsync(CuentaConsumidorFinal);
        }
        #endregion


        private void textBoxNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }


}
