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

namespace ElBrezal.Desktop.Forms.Tablas.Familias
{
    public partial class FamiliasForm : Form
    {
        private readonly IFamiliaService _familiaService;

        public FamiliasForm(IFamiliaService familiaService)
        {
            InitializeComponent();

            _familiaService = familiaService;
        }

        private async void FamiliasForm_Load(object? sender, EventArgs e)
        {
            try
            {
                ConfigurarGrilla();
                await CargarFamiliasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async Task CargarFamiliasAsync()
        {
            var familias = await _familiaService.ObtenerTodasAsync();

            dataGridViewFamilias.DataSource = familias;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nombre = textBoxDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Debe ingresar una descripción.",
                    "Familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxDescripcion.Focus();
                return;
            }

            try
            {
                await _familiaService.AgregarAsync(nombre);

                textBoxDescripcion.Clear();

                await CargarFamiliasAsync();

                textBoxDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo agregar la familia.\n\n{ex.Message}",
                    "Familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFamilias.CurrentRow?.DataBoundItem is not FamiliaDto familia)
            {
                MessageBox.Show(
                    "Seleccione una familia para eliminar.",
                    "Familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var resultado = MessageBox.Show(
                $"¿Desea eliminar la familia \"{familia.Nombre}\"?",
                "Eliminar familia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                await _familiaService.EliminarAsync(familia.Id);

                await CargarFamiliasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar la familia.\n\n{ex.Message}",
                    "Familias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FamiliasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void ConfigurarGrilla()
        {
            // Estilo visual común de ElBrezal
            DataGridViewStyles.AplicarEstiloBase(dataGridViewFamilias);

            // Comportamiento particular de esta grilla
            dataGridViewFamilias.AutoGenerateColumns = true;
            dataGridViewFamilias.AllowUserToAddRows = false;
            dataGridViewFamilias.AllowUserToDeleteRows = false;
            dataGridViewFamilias.MultiSelect = false;
            dataGridViewFamilias.ReadOnly = true;

            dataGridViewFamilias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
