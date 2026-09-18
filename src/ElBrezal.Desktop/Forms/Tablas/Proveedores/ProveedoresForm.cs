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

namespace ElBrezal.Desktop.Forms.Tablas.Proveedores
{
    public partial class ProveedoresForm : Form
    {
        private readonly IProveedorService _proveedorService;
        private readonly ILocalidadService _localidadService;
        private readonly ISituacionImpositivaService _situacionImpositivaService;
        private readonly IServiceProvider _serviceProvider;

        private enum ModoFormulario
        {
            Consulta,
            Nuevo,
            Modificar
        }

        private ModoFormulario _modo = ModoFormulario.Consulta;

        public ProveedoresForm(
            IProveedorService proveedorService,
            ILocalidadService localidadService,
            ISituacionImpositivaService situacionImpositivaService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _proveedorService = proveedorService;
            _localidadService = localidadService;
            _situacionImpositivaService = situacionImpositivaService;
            _serviceProvider = serviceProvider;

            KeyPreview = true;
        }

        private async void ProveedoresForm_Load(object sender, EventArgs e)
        {
            await CargarLocalidadesAsync();
            await CargarSituacionesImpositivasAsync();
            await CargarProveedoresAsync();

            VolverModoConsulta();
        }

        private async Task CargarProveedoresAsync()
        {
            var proveedores = await _proveedorService.ObtenerTodosAsync();

            bindingSourceProveedores.DataSource = proveedores;

            if (proveedores.Count > 0)
            {
                bindingSourceProveedores.Position = 0;
                ActualizarProveedorActual();
            }
            else
            {
                LimpiarCampos();
            }

            ActualizarPosicion();
        }

        private async Task CargarLocalidadesAsync()
        {
            var localidades = await _localidadService.ObtenerTodasAsync();

            bindingSourceLocalidades.DataSource = localidades;

            cmbLocalidades.DataSource = bindingSourceLocalidades;
            cmbLocalidades.DisplayMember = "Nombre";
            cmbLocalidades.ValueMember = "Id";

            cmbLocalidades.SelectedIndex = -1;
        }

        private async Task CargarSituacionesImpositivasAsync()
        {
            var situaciones = await _situacionImpositivaService.ObtenerTodasAsync();

            bindingSourceSituacionesImpositivas.DataSource = situaciones;

            cmbSituacionImpositiva.DataSource = bindingSourceSituacionesImpositivas;
            cmbSituacionImpositiva.DisplayMember = "Nombre";
            cmbSituacionImpositiva.ValueMember = "Id";

            cmbSituacionImpositiva.SelectedIndex = -1;
        }

        private void ActualizarProveedorActual()
        {
            if (bindingSourceProveedores.Current is not ProveedorDto proveedor)
            {
                LimpiarCampos();
                ActualizarPosicion();
                return;
            }

            textBoxCodigo.Text = proveedor.Id.ToString();
            textBoxNombre.Text = proveedor.Nombre;
            textBoxDireccion.Text = proveedor.Direccion ?? string.Empty;

            if (proveedor.LocalidadId.HasValue)
                cmbLocalidades.SelectedValue = proveedor.LocalidadId.Value;
            else
                cmbLocalidades.SelectedIndex = -1;

            textBoxCodigoPostal.Text = proveedor.CodigoPostal ?? string.Empty;
            textBoxProvincia.Text = proveedor.Provincia ?? string.Empty;

            textBoxTelefono.Text = proveedor.Telefono ?? string.Empty;

            textBoxCUIT.Text = proveedor.CUIT ?? string.Empty;
            textBoxIngresosBrutos.Text = proveedor.IngresosBrutos ?? string.Empty;
            textBoxEmail.Text = proveedor.Email ?? string.Empty;

            if (proveedor.SituacionImpositivaId.HasValue)
                cmbSituacionImpositiva.SelectedValue =
                    proveedor.SituacionImpositivaId.Value;
            else
                cmbSituacionImpositiva.SelectedIndex = -1;

            richTextBoxObservaciones.Text =
                proveedor.Observacion ?? string.Empty;

            ActualizarPosicion();
        }

        private void bindingSourceProveedores_PositionChanged(
            object sender,
            EventArgs e)
        {
            if (_modo == ModoFormulario.Consulta)
                ActualizarProveedorActual();
        }

        private void cmbLocalidades_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cmbLocalidades.SelectedItem is LocalidadDto localidad)
            {
                textBoxCodigoPostal.Text = localidad.CodigoPostal;
                textBoxProvincia.Text = localidad.Provincia;
            }
            else
            {
                textBoxCodigoPostal.Clear();
                textBoxProvincia.Clear();
            }
        }

        private async void btnNuevaLocalidad_Click(object sender, EventArgs e)
        {
            int? localidadSeleccionada = cmbLocalidades.SelectedValue as int?;

            using var scope = _serviceProvider.CreateScope();

            var form = scope.ServiceProvider
                .GetRequiredService<LocalidadesForm>();

            form.ShowDialog(this);

            await CargarLocalidadesAsync();

            if (localidadSeleccionada.HasValue)
                cmbLocalidades.SelectedValue = localidadSeleccionada.Value;
        }

        private void btnVerificarCuit_Click(object sender, EventArgs e)
        {
            var cuit = ObtenerCuit();

            if (string.IsNullOrWhiteSpace(cuit))
            {
                MessageBox.Show(
                    "Ingrese un CUIT.",
                    "Verificación de CUIT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (bindingSourceProveedores.Count > 0)
                bindingSourceProveedores.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (bindingSourceProveedores.Count > 0)
                bindingSourceProveedores.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (bindingSourceProveedores.Count > 0)
                bindingSourceProveedores.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (bindingSourceProveedores.Count > 0)
                bindingSourceProveedores.MoveLast();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_modo != ModoFormulario.Nuevo)
            {
                _modo = ModoFormulario.Nuevo;

                LimpiarCampos();
                HabilitarEdicion(true);
                HabilitarNavegacion(false);

                btnNuevo.Text = "Guardar";
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;

                textBoxNombre.Focus();

                return;
            }

            if (!ValidarCampos())
                return;

            var proveedor = CrearDtoDesdeFormulario();

            await _proveedorService.AgregarAsync(proveedor);

            await CargarProveedoresAsync();

            VolverModoConsulta();

            PosicionarProveedor(proveedor.Nombre);
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (bindingSourceProveedores.Current is not ProveedorDto actual)
                return;

            if (_modo != ModoFormulario.Modificar)
            {
                _modo = ModoFormulario.Modificar;

                HabilitarEdicion(true);
                HabilitarNavegacion(false);

                btnModificar.Text = "Guardar";
                btnNuevo.Enabled = false;
                btnEliminar.Enabled = false;

                textBoxNombre.Focus();

                return;
            }

            if (!ValidarCampos())
                return;

            var proveedor = CrearDtoDesdeFormulario();
            proveedor.Id = actual.Id;

            await _proveedorService.ModificarAsync(proveedor);

            int id = proveedor.Id;

            await CargarProveedoresAsync();

            VolverModoConsulta();

            PosicionarProveedor(id);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (bindingSourceProveedores.Current is not ProveedorDto proveedor)
                return;

            var resultado = MessageBox.Show(
                $"¿Desea eliminar el proveedor '{proveedor.Nombre}'?",
                "Eliminar proveedor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            await _proveedorService.EliminarAsync(proveedor.Id);

            await CargarProveedoresAsync();

            VolverModoConsulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ProveedorDto CrearDtoDesdeFormulario()
        {
            return new ProveedorDto
            {
                Nombre = textBoxNombre.Text.Trim(),

                Direccion = string.IsNullOrWhiteSpace(textBoxDireccion.Text)
                    ? null
                    : textBoxDireccion.Text.Trim(),

                LocalidadId = cmbLocalidades.SelectedValue is int localidadId
                    ? localidadId
                    : null,

                Telefono = string.IsNullOrWhiteSpace(textBoxTelefono.Text)
                    ? null
                    : textBoxTelefono.Text.Trim(),

                CUIT = ObtenerCuit(),

                IngresosBrutos =
                    string.IsNullOrWhiteSpace(textBoxIngresosBrutos.Text)
                        ? null
                        : textBoxIngresosBrutos.Text.Trim(),

                Email = string.IsNullOrWhiteSpace(textBoxEmail.Text)
                    ? null
                    : textBoxEmail.Text.Trim(),

                SituacionImpositivaId =
                    cmbSituacionImpositiva.SelectedValue is int situacionId
                        ? situacionId
                        : null,

                Observacion =
                    string.IsNullOrWhiteSpace(richTextBoxObservaciones.Text)
                        ? null
                        : richTextBoxObservaciones.Text.Trim()
            };
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del proveedor.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNombre.Focus();

                return false;
            }

            var cuit = ObtenerCuit();

            if (!string.IsNullOrWhiteSpace(cuit) &&
                !CuitValidator.Validar(cuit))
            {
                MessageBox.Show(
                    "El CUIT ingresado no es válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxCUIT.Focus();

                return false;
            }

            return true;
        }

        private string? ObtenerCuit()
        {
            var formatoAnterior = textBoxCUIT.TextMaskFormat;

            textBoxCUIT.TextMaskFormat =
                MaskFormat.ExcludePromptAndLiterals;

            string cuit = textBoxCUIT.Text.Trim();

            textBoxCUIT.TextMaskFormat = formatoAnterior;

            return string.IsNullOrWhiteSpace(cuit)
                ? null
                : cuit;
        }

        private void HabilitarEdicion(bool habilitar)
        {
            textBoxNombre.ReadOnly = !habilitar;
            textBoxDireccion.ReadOnly = !habilitar;

            cmbLocalidades.Enabled = habilitar;
            btnNuevaLocalidad.Enabled = habilitar;

            textBoxTelefono.ReadOnly = !habilitar;

            textBoxCUIT.ReadOnly = !habilitar;
            btnVerificarCuit.Enabled = habilitar;

            textBoxIngresosBrutos.ReadOnly = !habilitar;
            textBoxEmail.ReadOnly = !habilitar;

            cmbSituacionImpositiva.Enabled = habilitar;

            richTextBoxObservaciones.ReadOnly = !habilitar;
        }

        private void HabilitarNavegacion(bool habilitar)
        {
            btnPrimero.Enabled = habilitar;
            btnAnterior.Enabled = habilitar;
            btnSiguiente.Enabled = habilitar;
            btnUltimo.Enabled = habilitar;
        }

        private void LimpiarCampos()
        {
            textBoxCodigo.Clear();
            textBoxNombre.Clear();
            textBoxDireccion.Clear();

            cmbLocalidades.SelectedIndex = -1;
            textBoxCodigoPostal.Clear();
            textBoxProvincia.Clear();

            textBoxTelefono.Clear();

            textBoxCUIT.Clear();
            textBoxIngresosBrutos.Clear();
            textBoxEmail.Clear();

            cmbSituacionImpositiva.SelectedIndex = -1;

            richTextBoxObservaciones.Clear();
        }

        private void VolverModoConsulta()
        {
            _modo = ModoFormulario.Consulta;

            HabilitarEdicion(false);
            HabilitarNavegacion(true);

            btnNuevo.Text = "Nuevo";
            btnModificar.Text = "Modificar";

            btnNuevo.Enabled = true;
            btnModificar.Enabled =
                bindingSourceProveedores.Count > 0;
            btnEliminar.Enabled =
                bindingSourceProveedores.Count > 0;

            btnSalir.Enabled = true;

            ActualizarProveedorActual();
        }

        private void ActualizarPosicion()
        {
            if (bindingSourceProveedores.Count == 0)
            {
                lblPosicion.Text = "0 / 0";
                return;
            }

            lblPosicion.Text =
                $"{bindingSourceProveedores.Position + 1} / " +
                $"{bindingSourceProveedores.Count}";
        }

        private void PosicionarProveedor(int id)
        {
            for (int i = 0; i < bindingSourceProveedores.Count; i++)
            {
                if (bindingSourceProveedores[i] is ProveedorDto proveedor &&
                    proveedor.Id == id)
                {
                    bindingSourceProveedores.Position = i;
                    return;
                }
            }
        }

        private void PosicionarProveedor(string nombre)
        {
            for (int i = 0; i < bindingSourceProveedores.Count; i++)
            {
                if (bindingSourceProveedores[i] is ProveedorDto proveedor &&
                    proveedor.Nombre.Equals(
                        nombre,
                        StringComparison.OrdinalIgnoreCase))
                {
                    bindingSourceProveedores.Position = i;
                    return;
                }
            }
        }

        private void ProveedoresForm_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            if (_modo == ModoFormulario.Consulta)
            {
                Close();
                return;
            }

            VolverModoConsulta();

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void textBoxTelefono_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '+' && sender is TextBox textBox)
            {
                if (textBox.SelectionStart != 0 ||
                    textBox.Text.Contains('+'))
                {
                    e.Handled = true;
                }
            }
        }
    }
}