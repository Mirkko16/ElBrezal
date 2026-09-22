using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Application.Validators;
using ElBrezal.Desktop.Forms.Tablas.Localidades;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Clientes.ActualizacionClientes
{
    public partial class ClientesForm : Form
    {
        private readonly IClienteService _clienteService;
        private readonly ILocalidadService _localidadService;
        private readonly ISituacionImpositivaService _situacionImpositivaService;
        private readonly IEstadoCuentaClienteService _estadoCuentaClienteService;
        private readonly IVendedorService _vendedorService;
        private readonly IServiceProvider _serviceProvider;

        private enum ModoFormulario
        {
            Consulta,
            Nuevo,
            Modificar
        }

        private ModoFormulario _modoActual = ModoFormulario.Consulta;

        public ClientesForm(
            IClienteService clienteService,
            ILocalidadService localidadService,
            ISituacionImpositivaService situacionImpositivaService,
            IEstadoCuentaClienteService estadoCuentaClienteService,
            IVendedorService vendedorService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _clienteService = clienteService;
            _localidadService = localidadService;
            _situacionImpositivaService = situacionImpositivaService;
            _estadoCuentaClienteService = estadoCuentaClienteService;
            _vendedorService = vendedorService;
            _serviceProvider = serviceProvider;

            KeyPreview = true;
        }

        private async void ActualizacionClientesForm_Load(object sender, EventArgs e)
        {
            await CargarLocalidadesAsync();
            await CargarSituacionesImpositivasAsync();
            await CargarEstadosCuentaAsync();
            await CargarVendedoresAsync();
            await CargarClientesAsync();

            VolverModoConsulta();
        }

        private async Task CargarLocalidadesAsync()
        {
            var localidades = await _localidadService.ObtenerTodasAsync();

            bindingSourceLocalidades.DataSource = localidades;

            cmbLocalidades.DataSource = bindingSourceLocalidades;
            cmbLocalidades.DisplayMember = nameof(LocalidadDto.Nombre);
            cmbLocalidades.ValueMember = nameof(LocalidadDto.Id);
        }

        private async Task CargarSituacionesImpositivasAsync()
        {
            var situaciones = await _situacionImpositivaService.ObtenerTodasAsync();

            bindingSourceSituacionesImpositivas.DataSource = situaciones;

            cmbSituacionImpositiva.DataSource = bindingSourceSituacionesImpositivas;
            cmbSituacionImpositiva.DisplayMember = nameof(SituacionImpositivaDto.Nombre);
            cmbSituacionImpositiva.ValueMember = nameof(SituacionImpositivaDto.Id);
        }

        private async Task CargarEstadosCuentaAsync()
        {
            var estados = await _estadoCuentaClienteService.ObtenerTodosAsync();

            bindingSourceEstadosCuenta.DataSource = estados;

            cmbEstadoCuenta.DataSource = bindingSourceEstadosCuenta;
            cmbEstadoCuenta.DisplayMember = nameof(EstadoCuentaClienteDto.Nombre);
            cmbEstadoCuenta.ValueMember = nameof(EstadoCuentaClienteDto.Id);
        }

        private async Task CargarVendedoresAsync()
        {
            var vendedores = await _vendedorService.ObtenerTodosAsync();

            bindingSourceVendedores.DataSource = vendedores;

            cmbVendedor.DataSource = bindingSourceVendedores;
            cmbVendedor.DisplayMember = nameof(VendedorDto.Nombre);
            cmbVendedor.ValueMember = nameof(VendedorDto.Id);
        }

        private async Task CargarClientesAsync()
        {
            var clientes = await _clienteService.ObtenerTodosAsync();

            bindingSourceClientes.DataSource = clientes;

            ActualizarClienteActual();
        }

        private void ActualizarClienteActual()
        {
            if (bindingSourceClientes.Current is not ClienteDto cliente)
            {
                LimpiarCampos();

                lblPosicion.Text = "0/0";

                return;
            }

            textBoxCodigo.Text = cliente.Id.ToString();
            textBoxNombre.Text = cliente.Nombre;
            textBoxDNI.Text = cliente.DNI ?? string.Empty;
            textBoxDireccion.Text = cliente.Direccion ?? string.Empty;

            cmbLocalidades.SelectedValue = cliente.LocalidadId;

            textBoxCodigoPostal.Text = cliente.CodigoPostal;
            textBoxProvincia.Text = cliente.Provincia;

            textBoxTelefono.Text = cliente.Telefono ?? string.Empty;
            textBoxEmail.Text = cliente.Email ?? string.Empty;

            cmbSituacionImpositiva.SelectedValue =
                cliente.SituacionImpositivaId;

            textBoxCUIT.Text = cliente.CUIT ?? string.Empty;
            textBoxIngresosBrutos.Text =
                cliente.IngresosBrutos ?? string.Empty;

            cmbEstadoCuenta.SelectedValue =
                cliente.EstadoCuentaId;

            if (cliente.VendedorId.HasValue)
                cmbVendedor.SelectedValue = cliente.VendedorId.Value;
            else
                cmbVendedor.SelectedIndex = -1;

            richTextBoxObservaciones.Text =
                cliente.Observacion ?? string.Empty;

            lblPosicion.Text =
                $"{bindingSourceClientes.Position + 1}/{bindingSourceClientes.Count}";
        }

        private void bindingSourceClientes_PositionChanged(
            object? sender,
            EventArgs e)
        {
            if (_modoActual == ModoFormulario.Consulta)
                ActualizarClienteActual();
        }

        private void cmbLocalidades_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            ActualizarDatosLocalidad();
        }

        private void ActualizarDatosLocalidad()
        {
            if (cmbLocalidades.SelectedItem is not LocalidadDto localidad)
            {
                textBoxCodigoPostal.Clear();
                textBoxProvincia.Clear();
                return;
            }

            textBoxCodigoPostal.Text = localidad.CodigoPostal;
            textBoxProvincia.Text = localidad.Provincia;
        }

        private void btnVerificarCuit_Click(object sender, EventArgs e)
        {
            var cuit = ObtenerCuit();

            if (string.IsNullOrWhiteSpace(cuit))
            {
                MessageBox.Show(
                    "Debe ingresar un CUIT.",
                    "Verificación de CUIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxCUIT.Focus();

                return;
            }

            if (CuitValidator.Validar(cuit))
            {
                MessageBox.Show(
                    "El CUIT ingresado es válido.",
                    "Verificación de CUIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "El CUIT ingresado no es válido.",
                    "Verificación de CUIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxCUIT.Focus();
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            bindingSourceClientes.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bindingSourceClientes.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            bindingSourceClientes.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            bindingSourceClientes.MoveLast();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_modoActual != ModoFormulario.Nuevo)
            {
                _modoActual = ModoFormulario.Nuevo;

                LimpiarCampos();

                HabilitarEdicion(true);

                btnNuevo.Text = "Guardar";

                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;

                HabilitarNavegacion(false);

                textBoxNombre.Focus();

                return;
            }

            if (!ValidarCampos())
                return;

            var cliente = CrearDtoDesdeFormulario();

            await _clienteService.AgregarAsync(cliente);

            await CargarClientesAsync();

            if (bindingSourceClientes.Count > 0)
                bindingSourceClientes.MoveLast();

            VolverModoConsulta();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (bindingSourceClientes.Current is not ClienteDto clienteActual)
                return;

            if (_modoActual != ModoFormulario.Modificar)
            {
                _modoActual = ModoFormulario.Modificar;

                HabilitarEdicion(true);

                btnModificar.Text = "Guardar";

                btnNuevo.Enabled = false;
                btnEliminar.Enabled = false;

                HabilitarNavegacion(false);

                textBoxNombre.Focus();

                return;
            }

            if (!ValidarCampos())
                return;

            var cliente = CrearDtoDesdeFormulario();

            cliente.Id = clienteActual.Id;

            await _clienteService.ModificarAsync(cliente);

            int clienteId = cliente.Id;

            await CargarClientesAsync();

            PosicionarCliente(clienteId);

            VolverModoConsulta();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (bindingSourceClientes.Current is not ClienteDto cliente)
                return;

            var resultado = MessageBox.Show(
                $"¿Desea eliminar el cliente {cliente.Nombre}?",
                "Eliminar cliente",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            await _clienteService.EliminarAsync(cliente.Id);

            await CargarClientesAsync();

            VolverModoConsulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnNuevaLocalidad_Click(object sender, EventArgs e)
        {
            int? localidadSeleccionada = null;

            if (cmbLocalidades.SelectedValue is int id)
                localidadSeleccionada = id;

            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider
                .GetRequiredService<LocalidadesForm>();

            form.ShowDialog(this);

            await CargarLocalidadesAsync();

            if (localidadSeleccionada.HasValue)
                cmbLocalidades.SelectedValue = localidadSeleccionada.Value;
            else
                cmbLocalidades.SelectedIndex = -1;

            ActualizarDatosLocalidad();
        }

        private ClienteDto CrearDtoDesdeFormulario()
        {
            int localidadId =
                cmbLocalidades.SelectedValue is int localidad
                    ? localidad
                    : 0;

            int situacionImpositivaId =
                cmbSituacionImpositiva.SelectedValue is int situacion
                    ? situacion
                    : 0;

            int estadoCuentaId =
                cmbEstadoCuenta.SelectedValue is int estado
                    ? estado
                    : 0;

            int? vendedorId = null;

            if (cmbVendedor.SelectedValue is int vendedor)
                vendedorId = vendedor;

            return new ClienteDto
            {
                Nombre = textBoxNombre.Text,
                DNI = textBoxDNI.Text,
                CUIT = ObtenerCuit(),
                IngresosBrutos = textBoxIngresosBrutos.Text,
                Direccion = textBoxDireccion.Text,

                LocalidadId = localidadId,

                Telefono = textBoxTelefono.Text,
                Email = textBoxEmail.Text,

                SituacionImpositivaId = situacionImpositivaId,
                EstadoCuentaId = estadoCuentaId,
                VendedorId = vendedorId,

                Observacion = richTextBoxObservaciones.Text
            };
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del cliente.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNombre.Focus();

                return false;
            }

            if (cmbLocalidades.SelectedValue is not int)
            {
                MessageBox.Show(
                    "Debe seleccionar una localidad.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbLocalidades.Focus();

                return false;
            }

            if (cmbSituacionImpositiva.SelectedValue is not int)
            {
                MessageBox.Show(
                    "Debe seleccionar una situación impositiva.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbSituacionImpositiva.Focus();

                return false;
            }

            if (cmbEstadoCuenta.SelectedValue is not int)
            {
                MessageBox.Show(
                    "Debe seleccionar un estado de cuenta.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEstadoCuenta.Focus();

                return false;
            }

            var cuit = ObtenerCuit();

            if (!string.IsNullOrWhiteSpace(cuit) &&
                !CuitValidator.Validar(cuit))
            {
                MessageBox.Show(
                    "El CUIT ingresado no es válido.",
                    "Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxCUIT.Focus();

                return false;
            }

            return true;
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

        private void LimpiarCampos()
        {
            textBoxCodigo.Clear();
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxDireccion.Clear();

            cmbLocalidades.SelectedIndex = -1;

            textBoxCodigoPostal.Clear();
            textBoxProvincia.Clear();

            textBoxTelefono.Clear();
            textBoxEmail.Clear();

            cmbSituacionImpositiva.SelectedIndex = -1;

            textBoxCUIT.Clear();
            textBoxIngresosBrutos.Clear();

            cmbEstadoCuenta.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;

            richTextBoxObservaciones.Clear();
        }

        private void HabilitarEdicion(bool habilitar)
        {
            textBoxNombre.ReadOnly = !habilitar;
            textBoxDNI.ReadOnly = !habilitar;
            textBoxDireccion.ReadOnly = !habilitar;

            cmbLocalidades.Enabled = habilitar;
            btnNuevaLocalidad.Enabled = habilitar;

            textBoxTelefono.ReadOnly = !habilitar;
            textBoxEmail.ReadOnly = !habilitar;

            cmbSituacionImpositiva.Enabled = habilitar;

            textBoxCUIT.ReadOnly = !habilitar;
            btnVerificarCuit.Enabled = habilitar;

            textBoxIngresosBrutos.ReadOnly = !habilitar;

            cmbEstadoCuenta.Enabled = habilitar;
            cmbVendedor.Enabled = habilitar;

            richTextBoxObservaciones.ReadOnly = !habilitar;

            textBoxCodigo.ReadOnly = true;
            textBoxCodigoPostal.ReadOnly = true;
            textBoxProvincia.ReadOnly = true;
        }

        private void HabilitarNavegacion(bool habilitar)
        {
            btnPrimero.Enabled = habilitar;
            btnAnterior.Enabled = habilitar;
            btnSiguiente.Enabled = habilitar;
            btnUltimo.Enabled = habilitar;
        }

        private void VolverModoConsulta()
        {
            _modoActual = ModoFormulario.Consulta;

            btnNuevo.Text = "Nuevo";
            btnModificar.Text = "Modificar";

            btnNuevo.Enabled = true;

            bool hayClientes = bindingSourceClientes.Count > 0;

            btnModificar.Enabled = hayClientes;
            btnEliminar.Enabled = hayClientes;

            HabilitarNavegacion(hayClientes);
            HabilitarEdicion(false);

            ActualizarClienteActual();
        }

        private void PosicionarCliente(int clienteId)
        {
            for (int i = 0; i < bindingSourceClientes.Count; i++)
            {
                if (bindingSourceClientes[i] is ClienteDto cliente &&
                    cliente.Id == clienteId)
                {
                    bindingSourceClientes.Position = i;
                    break;
                }
            }
        }

        private void ActualizacionClientesForm_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            if (_modoActual == ModoFormulario.Consulta)
            {
                Close();
                return;
            }

            VolverModoConsulta();

            e.Handled = true;
        }

        private void textBoxTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '+')
                {
                    e.Handled = true;
                }

                // Solo permitimos un "+" y únicamente al principio
                if (e.KeyChar == '+' && sender is TextBox textBox)
                {
                    if (textBox.SelectionStart != 0 || textBox.Text.Contains('+'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '+')
                {
                    e.Handled = true;
                }

                // Solo permitimos un "+" y únicamente al principio
                if (e.KeyChar == '+' && sender is TextBox textBox)
                {
                    if (textBox.SelectionStart != 0 || textBox.Text.Contains('+'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBoxNumCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
