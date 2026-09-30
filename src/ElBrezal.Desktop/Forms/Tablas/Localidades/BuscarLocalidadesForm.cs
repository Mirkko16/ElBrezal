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

namespace ElBrezal.Desktop.Forms.Tablas.Localidades
{
    public partial class BuscarLocalidadesForm : Form
    {
        private readonly ILocalidadService _localidadService;

        private List<LocalidadDto> _localidades = new();

        public LocalidadDto? LocalidadSeleccionada { get; private set; }

        public BuscarLocalidadesForm(ILocalidadService localidadService)
        {
            InitializeComponent();

            _localidadService = localidadService;
        }

        private async void BuscarLocalidadesForm_Load(object sender, EventArgs e)
        {
            ConfigurarGrilla();

            _localidades = await _localidadService.ObtenerTodasAsync();

            MostrarLocalidades(_localidades);

            textBoxBuscar.Focus();
        }

        private void ConfigurarGrilla()
        {
            DataGridViewStyles.AplicarEstiloBase(dataGridViewLocalidades);

            dataGridViewLocalidades.ReadOnly = true;
            dataGridViewLocalidades.MultiSelect = false;
            dataGridViewLocalidades.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewLocalidades.AllowUserToAddRows = false;
            dataGridViewLocalidades.AllowUserToDeleteRows = false;
            dataGridViewLocalidades.AutoGenerateColumns = false;

            // Binding de columnas
            dataGridViewTextBoxColumnId.DataPropertyName =
                nameof(LocalidadDto.Id);

            dataGridViewTextBoxColumnCodigoPostal.DataPropertyName =
                nameof(LocalidadDto.CodigoPostal);

            dataGridViewTextBoxColumnNombre.DataPropertyName =
                nameof(LocalidadDto.Nombre);

            
            // Distribución
            dataGridViewTextBoxColumnId.FillWeight = 12;
            dataGridViewTextBoxColumnCodigoPostal.FillWeight = 45;
            dataGridViewTextBoxColumnNombre.FillWeight = 20;
            
        }

        private void MostrarLocalidades(IEnumerable<LocalidadDto> localidades)
        {
            dataGridViewLocalidades.DataSource = localidades.ToList();

            if (dataGridViewLocalidades.Rows.Count == 0)
                return;

            dataGridViewLocalidades.ClearSelection();

            dataGridViewLocalidades.Rows[0].Selected = true;
            dataGridViewLocalidades.CurrentCell =
                dataGridViewLocalidades.Rows[0].Cells[0];
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            var texto = textBoxBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MostrarLocalidades(_localidades);
                return;
            }

            var localidadesFiltradas = _localidades
                .Where(x =>
                    x.Id.ToString().Contains(texto) ||
                    x.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (x.CodigoPostal?.Contains(
                        texto,
                        StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

            MostrarLocalidades(localidadesFiltradas);
        }

        private void SeleccionarCliente()
        {
            if (dataGridViewLocalidades.CurrentRow?.DataBoundItem
                is not LocalidadDto localidad)
            {
                return;
            }

            LocalidadSeleccionada = localidad;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dataGridViewLocalidades_CellDoubleClick(
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
            if (dataGridViewLocalidades.Rows.Count == 0)
                return;

            int indiceActual =
                dataGridViewLocalidades.CurrentRow?.Index ?? 0;

            int nuevoIndice = Math.Clamp(
                indiceActual + direccion,
                0,
                dataGridViewLocalidades.Rows.Count - 1);

            dataGridViewLocalidades.ClearSelection();

            dataGridViewLocalidades.Rows[nuevoIndice].Selected = true;

            dataGridViewLocalidades.CurrentCell =
                dataGridViewLocalidades.Rows[nuevoIndice].Cells[0];
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
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
