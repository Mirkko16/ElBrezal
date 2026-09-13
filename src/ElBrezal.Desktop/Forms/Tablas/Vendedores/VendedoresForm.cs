using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;

namespace ElBrezal.Desktop.Forms.Tablas.Vendedores
{
    public partial class VendedoresForm : Form
    {
        private readonly IVendedorService _vendedorService;
        private readonly ILocalidadService _localidadService;

        private enum ModoFormulario
        {
            Consulta,
            Nuevo,
            Modificar
        }

        private ModoFormulario _modoActual = ModoFormulario.Consulta;

        public VendedoresForm(
            IVendedorService vendedorService,
            ILocalidadService localidadService)
        {
            InitializeComponent();

            _vendedorService = vendedorService;
            _localidadService = localidadService;

            KeyPreview = true;
        }

        private async void VendedoresForm_Load(object sender, EventArgs e)
        {
            await CargarLocalidadesAsync();
            await CargarVendedoresAsync();

            VolverModoConsulta();
        }

        private async Task CargarLocalidadesAsync()
        {
            var localidades = await _localidadService.ObtenerTodasAsync();

            bindingSourceLocalidadesVendedor.DataSource = localidades;

            cmbLocalidadesVendedor.DataSource = bindingSourceLocalidadesVendedor;
            cmbLocalidadesVendedor.DisplayMember = nameof(LocalidadDto.Nombre);
            cmbLocalidadesVendedor.ValueMember = nameof(LocalidadDto.Id);
        }

        private async Task CargarVendedoresAsync()
        {
            var vendedores = await _vendedorService.ObtenerTodosAsync();

            bindingSourceVendedores.DataSource = vendedores;

            ActualizarVendedorActual();
        }

        private void ActualizarVendedorActual()
        {
            if (bindingSourceVendedores.Current is not VendedorDto vendedor)
            {
                LimpiarCampos();
                lblPosicion.Text = "0/0";
                return;
            }

            textBoxIdVendedor.Text = vendedor.Id.ToString();
            textBoxNombreVendedor.Text = vendedor.Nombre;
            textBoxDireccionVendedor.Text = vendedor.Direccion ?? string.Empty;
            textBoxTelVendedor.Text = vendedor.Telefono ?? string.Empty;
            textBoxEmailVendedor.Text = vendedor.Email ?? string.Empty;

            if (vendedor.LocalidadId.HasValue)
                cmbLocalidadesVendedor.SelectedValue = vendedor.LocalidadId.Value;
            else
                cmbLocalidadesVendedor.SelectedIndex = -1;

            lblPosicion.Text =
                $"{bindingSourceVendedores.Position + 1}/{bindingSourceVendedores.Count}";
        }

        private void bindingSourceVendedores_PositionChanged(object sender, EventArgs e)
        {
            if (_modoActual == ModoFormulario.Consulta)
                ActualizarVendedorActual();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            bindingSourceVendedores.MoveFirst();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bindingSourceVendedores.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            bindingSourceVendedores.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            bindingSourceVendedores.MoveLast();
        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_modoActual != ModoFormulario.Nuevo)
            {
                _modoActual = ModoFormulario.Nuevo;

                LimpiarCampos();

                btnNuevo.Text = "Guardar";

                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;

                HabilitarNavegacion(false);

                textBoxNombreVendedor.Focus();

                return;
            }

            if (!ValidarCampos())
                return;

            var vendedor = CrearDtoDesdeFormulario();

            await _vendedorService.AgregarAsync(vendedor);

            await CargarVendedoresAsync();

            if (bindingSourceVendedores.Count > 0)
                bindingSourceVendedores.MoveLast();

            VolverModoConsulta();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (bindingSourceVendedores.Current is not VendedorDto vendedorActual)
                return;

            if (_modoActual != ModoFormulario.Modificar)
            {
                _modoActual = ModoFormulario.Modificar;

                btnModificar.Text = "Guardar";

                btnNuevo.Enabled = false;
                btnEliminar.Enabled = false;

                HabilitarNavegacion(false);

                textBoxNombreVendedor.Focus();

                return;
            }

            if (!ValidarCampos())
                return;

            var vendedor = CrearDtoDesdeFormulario();

            vendedor.Id = vendedorActual.Id;

            await _vendedorService.ModificarAsync(vendedor);

            int posicionActual = bindingSourceVendedores.Position;

            await CargarVendedoresAsync();

            if (posicionActual >= 0 &&
                posicionActual < bindingSourceVendedores.Count)
            {
                bindingSourceVendedores.Position = posicionActual;
            }

            VolverModoConsulta();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (bindingSourceVendedores.Current is not VendedorDto vendedor)
                return;

            var resultado = MessageBox.Show(
                $"¿Desea eliminar el vendedor {vendedor.Nombre}?",
                "Eliminar vendedor",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            await _vendedorService.EliminarAsync(vendedor.Id);

            await CargarVendedoresAsync();

            VolverModoConsulta();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private VendedorDto CrearDtoDesdeFormulario()
        {
            int? localidadId = null;

            if (cmbLocalidadesVendedor.SelectedValue is int id)
                localidadId = id;

            return new VendedorDto
            {
                Nombre = textBoxNombreVendedor.Text,
                Direccion = textBoxDireccionVendedor.Text,
                Telefono = textBoxTelVendedor.Text,
                LocalidadId = localidadId,
                Email = textBoxEmailVendedor.Text
            };
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreVendedor.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del vendedor.",
                    "Vendedor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxNombreVendedor.Focus();

                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            textBoxIdVendedor.Clear();
            textBoxNombreVendedor.Clear();
            textBoxDireccionVendedor.Clear();
            textBoxTelVendedor.Clear();
            textBoxEmailVendedor.Clear();

            cmbLocalidadesVendedor.SelectedIndex = -1;
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
            btnModificar.Enabled = bindingSourceVendedores.Count > 0;
            btnEliminar.Enabled = bindingSourceVendedores.Count > 0;

            HabilitarNavegacion(bindingSourceVendedores.Count > 0);

            ActualizarVendedorActual();
        }

        private void VendedoresForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            if (_modoActual == ModoFormulario.Consulta)
            {
                Close();
                return;
            }

            VolverModoConsulta();
        }
    }
}