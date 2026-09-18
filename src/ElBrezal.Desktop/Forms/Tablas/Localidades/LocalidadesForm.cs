using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;

namespace ElBrezal.Desktop.Forms.Tablas.Localidades
{
    public partial class LocalidadesForm : Form
    {
        private enum ModoFormulario
        {
            Consulta,
            Nuevo,
            Modificar
        }

        private ModoFormulario _modoActual = ModoFormulario.Consulta;
        private readonly ILocalidadService _localidadService;
        private readonly IProvinciaService _provinciaService;

        public LocalidadesForm(
            ILocalidadService localidadService,
            IProvinciaService provinciaService)
        {
            InitializeComponent();

            _localidadService = localidadService;
            _provinciaService = provinciaService;
        }

        private async void LocalidadesForm_Load(object sender, EventArgs e)
        {
            await CargarProvinciasAsync();
            await CargarLocalidadesAsync();
        }

        private async Task CargarProvinciasAsync()
        {
            var provincias = await _provinciaService.ObtenerTodasAsync();

            cmbProvincias.DataSource = provincias;
            cmbProvincias.DisplayMember = nameof(ProvinciaDto.Nombre);
            cmbProvincias.ValueMember = nameof(ProvinciaDto.Id);
        }

        private async Task CargarLocalidadesAsync()
        {
            var localidades = await _localidadService.ObtenerTodasAsync();

            bindingSourceLocalidades.DataSource = localidades;

            ActualizarLocalidadActual();
        }

        private void ActualizarLocalidadActual()
        {
            if (bindingSourceLocalidades.Current is not LocalidadDto localidad)
            {
                textBoxZona.Clear();
                textBoxCodigoPostal.Clear();
                textBoxLocalidad.Clear();
                cmbProvincias.SelectedIndex = -1;

                lblPosicion.Text = "0/0";
                return;
            }

            textBoxZona.Text = localidad.Id.ToString();
            textBoxCodigoPostal.Text = localidad.CodigoPostal;
            textBoxLocalidad.Text = localidad.Nombre;

            cmbProvincias.SelectedValue = localidad.ProvinciaId;

            var actual = bindingSourceLocalidades.Position + 1;
            var total = bindingSourceLocalidades.Count;

            lblPosicion.Text = $"{actual}/{total}";
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            bindingSourceLocalidades.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bindingSourceLocalidades.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            bindingSourceLocalidades.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            bindingSourceLocalidades.MoveLast();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_modoActual == ModoFormulario.Nuevo)
            {
                await GuardarNuevaLocalidadAsync();
                return;
            }

            _modoActual = ModoFormulario.Nuevo;

            textBoxZona.Clear();
            textBoxCodigoPostal.Clear();
            textBoxLocalidad.Clear();
            cmbProvincias.SelectedIndex = -1;

            textBoxCodigoPostal.Focus();

            btnNuevo.Text = "Guardar";
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            btnPrimero.Enabled = false;
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (_modoActual == ModoFormulario.Modificar)
            {
                await GuardarModificacionAsync();
                return;
            }

            if (bindingSourceLocalidades.Current is not LocalidadDto)
                return;

            _modoActual = ModoFormulario.Modificar;

            btnModificar.Text = "Guardar";

            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;

            btnPrimero.Enabled = false;
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;

            textBoxCodigoPostal.Focus();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (bindingSourceLocalidades.Current is not LocalidadDto localidad)
                return;

            var resultado = MessageBox.Show(
                $"¿Desea eliminar la localidad {localidad.Nombre}?",
                "Eliminar localidad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            await _localidadService.EliminarAsync(localidad.Id);

            await CargarLocalidadesAsync();

            VolverModoConsulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LocalidadesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            if (_modoActual != ModoFormulario.Consulta)
            {
                VolverModoConsulta();
                return;
            }

            Close();
        }

        private async Task GuardarNuevaLocalidadAsync()
        {
            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text))
            {
                MessageBox.Show("Debe ingresar el código postal.");
                textBoxCodigoPostal.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLocalidad.Text))
            {
                MessageBox.Show("Debe ingresar la localidad.");
                textBoxLocalidad.Focus();
                return;
            }

            if (cmbProvincias.SelectedValue is not int provinciaId)
            {
                MessageBox.Show("Debe seleccionar una provincia.");
                cmbProvincias.Focus();
                return;
            }

            await _localidadService.AgregarAsync(
                textBoxLocalidad.Text,
                textBoxCodigoPostal.Text,
                provinciaId);

            await CargarLocalidadesAsync();

            VolverModoConsulta();
        }
        private void VolverModoConsulta()
        {
            _modoActual = ModoFormulario.Consulta;

            btnNuevo.Text = "Nuevo";
            btnModificar.Text = "Modificar";

            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;

            btnPrimero.Enabled = true;
            btnAnterior.Enabled = true;
            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;

            ActualizarLocalidadActual();
        }

        private async Task GuardarModificacionAsync()
        {
            if (bindingSourceLocalidades.Current is not LocalidadDto localidad)
                return;

            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text))
            {
                MessageBox.Show("Debe ingresar el código postal.");
                textBoxCodigoPostal.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxLocalidad.Text))
            {
                MessageBox.Show("Debe ingresar la localidad.");
                textBoxLocalidad.Focus();
                return;
            }

            if (cmbProvincias.SelectedValue is not int provinciaId)
            {
                MessageBox.Show("Debe seleccionar una provincia.");
                cmbProvincias.Focus();
                return;
            }

            await _localidadService.ModificarAsync(
                localidad.Id,
                textBoxLocalidad.Text,
                textBoxCodigoPostal.Text,
                provinciaId);

            await CargarLocalidadesAsync();

            VolverModoConsulta();
        }

        private void bindingSourceLocalidades_PositionChanged(object sender, EventArgs e)
        {
            if (_modoActual == ModoFormulario.Consulta)
            {
                ActualizarLocalidadActual();
            }
        }
    }
}