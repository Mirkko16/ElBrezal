using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Desktop.UI.Styles;

namespace ElBrezal.Desktop.Forms.Clientes
{
    public partial class BuscarClientesForm : Form
    {
        private readonly IClienteService _clienteService;

        private List<ClienteDto> _clientes = new();

        public ClienteDto? ClienteSeleccionado { get; private set; }

        public BuscarClientesForm(IClienteService clienteService)
        {
            InitializeComponent();

            _clienteService = clienteService;
        }

        private async void BuscarClientesForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();

            _clientes = await _clienteService.ObtenerTodosAsync();

            MostrarClientes(_clientes);

            textBoxBuscar.Focus();
        }

        private void ConfigurarGrilla()
        {
            DataGridViewStyles.AplicarEstiloBase(dataGridViewClientes);

            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.MultiSelect = false;
            dataGridViewClientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewClientes.AllowUserToAddRows = false;
            dataGridViewClientes.AllowUserToDeleteRows = false;
            dataGridViewClientes.AutoGenerateColumns = false;

            // Binding de columnas
            dataGridViewTextBoxColumnCuenta.DataPropertyName =
                nameof(ClienteDto.Id);

            dataGridViewTextBoxColumnNombre.DataPropertyName =
                nameof(ClienteDto.Nombre);

            dataGridViewTextBoxColumnCUIT.DataPropertyName =
                nameof(ClienteDto.CUIT);

            dataGridViewTextBoxColumnLocalidad.DataPropertyName =
                nameof(ClienteDto.Localidad);

            // Distribución
            dataGridViewTextBoxColumnCuenta.FillWeight = 12;
            dataGridViewTextBoxColumnNombre.FillWeight = 45;
            dataGridViewTextBoxColumnCUIT.FillWeight = 20;
            dataGridViewTextBoxColumnLocalidad.FillWeight = 23;
        }

        private void MostrarClientes(IEnumerable<ClienteDto> clientes)
        {
            dataGridViewClientes.DataSource = clientes.ToList();

            if (dataGridViewClientes.Rows.Count == 0)
                return;

            dataGridViewClientes.ClearSelection();

            dataGridViewClientes.Rows[0].Selected = true;
            dataGridViewClientes.CurrentCell =
                dataGridViewClientes.Rows[0].Cells[0];
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            var texto = textBoxBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarClientes(_clientes);
                return;
            }

            var clientesFiltrados = _clientes
                .Where(x =>
                    x.Id.ToString().Contains(texto) ||
                    x.Nombre.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase) ||
                    (x.CUIT?.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (x.DNI?.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

            MostrarClientes(clientesFiltrados);
        }

        private void SeleccionarCliente()
        {
            if (dataGridViewClientes.CurrentRow?.DataBoundItem
                is not ClienteDto cliente)
            {
                return;
            }

            ClienteSeleccionado = cliente;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridViewClientes_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SeleccionarCliente();
        }

        private void dataGridViewClientes_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            SeleccionarCliente();
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
                SeleccionarCliente();
                e.SuppressKeyPress = true;
            }
        }

        private void MoverSeleccion(int direccion)
        {
            if (dataGridViewClientes.Rows.Count == 0)
                return;

            int indiceActual =
                dataGridViewClientes.CurrentRow?.Index ?? 0;

            int nuevoIndice = Math.Clamp(
                indiceActual + direccion,
                0,
                dataGridViewClientes.Rows.Count - 1);

            dataGridViewClientes.ClearSelection();

            dataGridViewClientes.Rows[nuevoIndice].Selected = true;

            dataGridViewClientes.CurrentCell =
                dataGridViewClientes.Rows[nuevoIndice].Cells[0];
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
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