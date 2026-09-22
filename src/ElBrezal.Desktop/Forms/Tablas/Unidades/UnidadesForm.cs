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

namespace ElBrezal.Desktop.Forms.Tablas.Unidades
{
    public partial class UnidadesForm : Form
    {
        private readonly IUnidadService _unidadService;

        public UnidadesForm(IUnidadService unidadService)
        {
            InitializeComponent();

            _unidadService = unidadService;
        }

        private async void UnidadesForm_Load(object? sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                await CargarUnidadesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar unidades",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async Task CargarUnidadesAsync()
        {
            var unidades = await _unidadService.ObtenerTodasAsync();

            dataGridViewUnidades.DataSource = unidades;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var descripcion = textBoxDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show(
                    "Debe ingresar una descripción.",
                    "Unidades",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxDescripcion.Focus();
                return;
            }

            try
            {
                await _unidadService.AgregarAsync(descripcion);

                textBoxDescripcion.Clear();

                await CargarUnidadesAsync();

                textBoxDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo agregar la unidad.\n\n{ex.Message}",
                    "Unidades",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUnidades.CurrentRow?.DataBoundItem is not UnidadDto unidad)
            {
                MessageBox.Show(
                    "Seleccione una unidad para eliminar.",
                    "Unidades",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var resultado = MessageBox.Show(
                $"¿Desea eliminar la unidad \"{unidad.Descripcion}\"?",
                "Eliminar unidad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                await _unidadService.EliminarAsync(unidad.Id);

                await CargarUnidadesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar la unidad.\n\n{ex.Message}",
                    "Unidades",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UnidadesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }
        private void ConfigurarGrilla()
        {
            // Estilo visual común de ElBrezal
            DataGridViewStyles.AplicarEstiloBase(dataGridViewUnidades);

            // Comportamiento particular de esta grilla
            dataGridViewUnidades.AutoGenerateColumns = true;
            dataGridViewUnidades.AllowUserToAddRows = false;
            dataGridViewUnidades.AllowUserToDeleteRows = false;
            dataGridViewUnidades.MultiSelect = false;
            dataGridViewUnidades.ReadOnly = true;

            dataGridViewUnidades.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
