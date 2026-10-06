using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Desktop.Exporting;
using ElBrezal.Desktop.UI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Forms.Articulos.VentasArticulos
{
    public partial class VentasArticulosValorizadasForm : Form
    {
        private readonly IVentaArticuloService _ventaArticuloService;

        private List<VentaArticuloValorizadaDto> _ventasArticulos = new();

        private bool _formularioCargado;

        public VentasArticulosValorizadasForm(
             IVentaArticuloService ventaArticuloService)
        {
            InitializeComponent();

            _ventaArticuloService = ventaArticuloService;
        }

        private async void VentasArticulosValorizadasForm_Load(object sender, EventArgs e)
        {
            try
            {
                _formularioCargado = false;

                ConfigurarGrilla();

                dateTimePickerDesde.Value =
                    new DateTime(
                        DateTime.Today.Year,
                        DateTime.Today.Month,
                        1);

                dateTimePickerHasta.Value =
                    DateTime.Today;

                _formularioCargado = true;

                await CargarVentasArticulosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al cargar las ventas valorizadas.\n\n{ex.Message}",
                    "Ventas de artículos valorizadas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnMigrarExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigurarGrilla()
        {
            DataGridViewStyles.AplicarEstiloBase(dataGridViewVentasArticulos);

            dataGridViewVentasArticulos.AllowUserToAddRows = false;
            dataGridViewVentasArticulos.AllowUserToDeleteRows = false;

            dataGridViewVentasArticulos.ReadOnly = true;
            dataGridViewVentasArticulos.MultiSelect = false;

            dataGridViewVentasArticulos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridViewVentasArticulos.ScrollBars = ScrollBars.Vertical;

            DataGridViewTextBoxCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewTextBoxCantidad.DefaultCellStyle.Format = "N2";

            DataGridViewTextBoxTotal.DefaultCellStyle.Format = "N2";

            DataGridViewTextBoxCodigo.FillWeight = 15;
            DataGridViewTextBoxArticulo.FillWeight = 55;
            DataGridViewTextBoxCantidad.FillWeight = 15;
            DataGridViewTextBoxTotal.FillWeight = 24;
        }

        private async Task CargarVentasArticulosAsync()
        {
            _ventasArticulos =
                await _ventaArticuloService.ObtenerValorizadasAsync(
                    dateTimePickerDesde.Value.Date,
                    dateTimePickerHasta.Value.Date);

            dataGridViewVentasArticulos.Rows.Clear();

            foreach (var venta in _ventasArticulos)
            {
                var indice =
                    dataGridViewVentasArticulos.Rows.Add();

                var fila =
                    dataGridViewVentasArticulos.Rows[indice];

                fila.Tag = venta.ProductoId;

                fila.Cells[DataGridViewTextBoxCodigo.Name].Value =
                    venta.ProductoId.ToString("000000");

                fila.Cells[DataGridViewTextBoxArticulo.Name].Value =
                    venta.Articulo;

                fila.Cells[DataGridViewTextBoxCantidad.Name].Value =
                    venta.Cantidad;

                fila.Cells[DataGridViewTextBoxTotal.Name].Value =
                    venta.Total;
            }

            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            lblCantidadArticulos.Text =
                _ventasArticulos.Count.ToString();

            lblTotal.Text = $"$ {_ventasArticulos.Sum(x => x.Total):N2}";
        }

        private async Task AplicarFiltrosAsync()
        {
            if (dateTimePickerDesde.Value.Date > dateTimePickerHasta.Value.Date)
            {
                return;
            }

            try
            {
                await CargarVentasArticulosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error al consultar las ventas valorizadas.\n\n{ex.Message}",
                    "Ventas de artículos valorizadas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void dateTimePickerDesde_ValueChanged(object sender, EventArgs e)
        {
            if (!_formularioCargado)
                return;

            await AplicarFiltrosAsync();
        }

        private async void dateTimePickerHasta_ValueChanged(object sender, EventArgs e)
        {
            if (!_formularioCargado)
                return;

            await AplicarFiltrosAsync();
        }

        private void VentasArticulosValorizadasForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Close();
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (_ventasArticulos.Count == 0)
            {
                MessageBox.Show(
                    "No hay datos para exportar.",
                    "Ventas de artículos valorizadas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using var saveFileDialog = new SaveFileDialog
            {
                Title = "Exportar ventas de artículos valorizadas",
                Filter = "Archivo de Excel (*.xlsx)|*.xlsx",
                DefaultExt = "xlsx",
                AddExtension = true,
                FileName =
                    $"VentasArticulosValorizadas_" +
                    $"{dateTimePickerDesde.Value:yyyyMMdd}_" +
                    $"{dateTimePickerHasta.Value:yyyyMMdd}.xlsx"
            };

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var columnas =
                    new List<ExcelColumn<VentaArticuloValorizadaDto>>
                    {
                new()
                {
                    Titulo = "Código",
                    Valor = x => x.ProductoId
                },
                new()
                {
                    Titulo = "Artículo",
                    Valor = x => x.Articulo
                },
                new()
                {
                    Titulo = "Cantidad",
                    Valor = x => x.Cantidad,
                    Formato = "#,##0.00"
                },
                new()
                {
                    Titulo = "Total",
                    Valor = x => x.Total,
                    Formato = "$ #,##0.00"
                }
                    };

                var total =
                    _ventasArticulos.Sum(x => x.Total);

                ExcelExporter.Exportar(
                    rutaArchivo: saveFileDialog.FileName,
                    datos: _ventasArticulos,
                    titulo: "VENTAS DE ARTÍCULOS VALORIZADAS",
                    subtitulo:
                        $"Período: " +
                        $"{dateTimePickerDesde.Value:dd/MM/yyyy} al " +
                        $"{dateTimePickerHasta.Value:dd/MM/yyyy}",
                    columnas: columnas,
                    tituloTotal: "TOTAL",
                    total: total);

                MessageBox.Show(
                    "El archivo de Excel se exportó correctamente.",
                    "Exportación finalizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo exportar el archivo de Excel.\n\n{ex.Message}",
                    "Error al exportar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
