using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Tablas.Marcas
{


    public partial class MarcasForm : Form
    {
        private readonly IMarcaService _marcaService;

        public MarcasForm(IMarcaService marcaService)
        {
            InitializeComponent();

            _marcaService = marcaService;
        }

        private async void MarcasForm_Load(object? sender, EventArgs e)
        {
            try
            {
                await CargarMarcasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al cargar marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async Task CargarMarcasAsync()
        {
            var marcas = await _marcaService.ObtenerTodasAsync();

            dataGridViewMarcas.DataSource = marcas;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nombre = textBoxDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Debe ingresar una descripción.",
                    "Marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBoxDescripcion.Focus();
                return;
            }

            try
            {
                await _marcaService.AgregarAsync(nombre);

                textBoxDescripcion.Clear();

                await CargarMarcasAsync();

                textBoxDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo agregar la marca.\n\n{ex.Message}",
                    "Marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarcas.CurrentRow?.DataBoundItem is not MarcaDto marca)
            {
                MessageBox.Show(
                    "Seleccione una marca para eliminar.",
                    "Marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var resultado = MessageBox.Show(
                $"¿Desea eliminar la marca \"{marca.Nombre}\"?",
                "Eliminar marca",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
                return;

            try
            {
                await _marcaService.EliminarAsync(marca.Id);

                await CargarMarcasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo eliminar la marca.\n\n{ex.Message}",
                    "Marcas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MarcasForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

    }
}
