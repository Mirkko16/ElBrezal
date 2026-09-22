using System.Drawing;
using System.Windows.Forms;

namespace ElBrezal.Desktop.UI.Styles
{
    public static class DataGridViewStyles
    {
        /// <summary>
        /// Estilo estándar para grillas generales del sistema.
        /// Adecuado para listados, ABM y grillas con CheckBox.
        /// </summary>
        public static void AplicarEstiloBase(DataGridView dataGridView)
        {
            // Fuente monoespaciada para los datos
            dataGridView.DefaultCellStyle.Font =
                new Font("Courier New", 8.5F, FontStyle.Regular);

            // Encabezados
            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 8.5F, FontStyle.Bold);

            // Grilla compacta
            dataGridView.RowTemplate.Height = 22;
            dataGridView.ColumnHeadersHeight = 22;

            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            // Las columnas ocupan todo el ancho disponible
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.DefaultCellStyle.Padding =
                new Padding(2, 0, 2, 0);

            // Filas
            dataGridView.AllowUserToResizeRows = false;

            // Indicador lateral
            dataGridView.RowHeadersVisible = true;
            dataGridView.RowHeadersWidth = 24;
        }

        /// <summary>
        /// Estilo compacto para grillas de carga de comprobantes:
        /// Facturación, Remitos y Presupuestos.
        /// </summary>
        public static void AplicarEstiloVenta(DataGridView dataGridView)
        {
            
            dataGridView.DefaultCellStyle.Font =
                new Font("Courier New", 8F, FontStyle.Regular);

            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 8F, FontStyle.Bold);

            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.None;

            dataGridView.RowTemplate.Height = 18;

            // También modifica filas que ya existan.
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Height = 18;
            }

            dataGridView.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView.ColumnHeadersHeight = 22;

            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.DefaultCellStyle.Padding =
                new Padding(1, 0, 1, 0);

            dataGridView.AllowUserToResizeRows = false;

            // Para Ventas no necesitamos el indicador lateral.
            dataGridView.RowHeadersVisible = false;
            //Para el background blanco de la grilla, se debe setear el color de fondo de la grilla y el color de fondo de las celdas.
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.BackColor = Color.White;

            DibujarFilasVacias(dataGridView);
        }


        /// <summary>
        /// Estilo compacto para llenar la grilla de productos con renglones vacios evitando el fondo gris de la grilla.
        /// Facturación, Remitos y Presupuestos.
        /// </summary>
        private static void DibujarFilasVacias(DataGridView dataGridView)
        {
            dataGridView.Paint += (_, e) =>
            {
                if (dataGridView.Columns.Count == 0)
                    return;

                int alturaFila = dataGridView.RowTemplate.Height;

                if (alturaFila <= 0)
                    return;

                // Punto inicial: debajo de las filas reales.
                int y = dataGridView.ColumnHeadersHeight;

                foreach (DataGridViewRow fila in dataGridView.Rows)
                {
                    if (fila.Visible)
                        y += fila.Height;
                }

                using var lapiz = new Pen(dataGridView.GridColor);

                while (y < dataGridView.ClientSize.Height)
                {
                    // Línea horizontal completa
                    e.Graphics.DrawLine(
                        lapiz,
                        0,
                        y,
                        dataGridView.ClientSize.Width,
                        y);

                    // Líneas verticales usando la posición REAL
                    // que DataGridView asignó a cada columna.
                    foreach (DataGridViewColumn columna in dataGridView.Columns)
                    {
                        if (!columna.Visible)
                            continue;

                        Rectangle rect =
                            dataGridView.GetColumnDisplayRectangle(
                                columna.Index,
                                false);

                        if (rect.Width <= 0)
                            continue;

                        e.Graphics.DrawLine(
                            lapiz,
                            rect.Right - 1,
                            y,
                            rect.Right - 1,
                            Math.Min(
                                y + alturaFila,
                                dataGridView.ClientSize.Height));
                    }

                    y += alturaFila;
                }
            };
        }
    }
}
