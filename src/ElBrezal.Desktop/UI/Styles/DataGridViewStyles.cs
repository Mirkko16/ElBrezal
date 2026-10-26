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

            dataGridView.ColumnHeadersHeight = 26;

            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.DefaultCellStyle.Padding =
                new Padding(1, 0, 1, 0);

            dataGridView.AllowUserToResizeRows = false;

            // Para Ventas no necesitamos el indicador lateral.
            dataGridView.RowHeadersVisible = false;
            //Para el background blanco de la grilla, se debe setear el color de fondo de la grilla y el color de fondo de las celdas.
            dataGridView.BackgroundColor = Color.White;            
            dataGridView.DefaultCellStyle.BackColor = Color.White;

            DibujarFilasVacias(dataGridView);
        }

        public static void AplicarEstiloPresupuesto(DataGridView dataGridView)
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

            dataGridView.ColumnHeadersHeight = 26;

            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView.DefaultCellStyle.Padding =
                new Padding(1, 0, 1, 0);

            dataGridView.AllowUserToResizeRows = false;

            // Para Ventas no necesitamos el indicador lateral.
            dataGridView.RowHeadersVisible = false;
            //Para el background blanco de la grilla, se debe setear el color de fondo de la grilla y el color de fondo de las celdas.
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


        /// <summary>
        /// Estilo para la grilla de comprobantes pendientes
        /// de autorización electrónica ante ARCA.
        /// </summary>
        public static void AplicarEstiloComprobantesPendientes(
            DataGridView dataGridView)
        {
            // Reutilizamos la configuración general del sistema.
            AplicarEstiloBase(dataGridView);

            // Configuración de grilla de consulta.
            dataGridView.AutoGenerateColumns = false;
            dataGridView.ReadOnly = true;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;

            dataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView.MultiSelect = false;

            dataGridView.RowHeadersVisible = false;

            // Tamaño compacto.
            dataGridView.RowTemplate.Height = 20;

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                fila.Height = 20;
            }

            dataGridView.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView.ColumnHeadersHeight = 26;

            // Aprovechar todo el ancho disponible.
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Apariencia.
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.BackColor = Color.White;

            dataGridView.DefaultCellStyle.Font =
                new Font("Courier New", 8.5F, FontStyle.Regular);

            dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 8.5F, FontStyle.Bold);

            dataGridView.DefaultCellStyle.Padding =
                new Padding(2, 0, 2, 0);

            dataGridView.EnableHeadersVisualStyles = false;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(225, 230, 235);

            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Black;

            // Selección.
            dataGridView.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 120, 215);

            dataGridView.DefaultCellStyle.SelectionForeColor =
                Color.White;

            // Filas alternadas.
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dataGridView.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 120, 215);

            dataGridView.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                Color.White;

            dataGridView.GridColor =
                Color.FromArgb(215, 215, 215);

            dataGridView.BorderStyle = BorderStyle.FixedSingle;

            // Evitamos que se marque automáticamente una fila
            // al mostrar los resultados.
            dataGridView.DataBindingComplete += (_, _) =>
            {
                dataGridView.ClearSelection();
                dataGridView.CurrentCell = null;
            };

            // Colores para los estados de autorización electrónica.
            AplicarColoresEstadosArca(dataGridView);
        }


        /// <summary>
        /// Aplica colores a la columna de estado de autorización ARCA.
        /// Sólo modifica la celda de estado, no toda la fila.
        /// </summary>
        public static void AplicarColoresEstadosArca(
            DataGridView dataGridView,
            string nombreColumnaEstado = "DataGridViewTextBoxColEstado")
        {
            dataGridView.CellFormatting += (_, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (dataGridView.Columns[e.ColumnIndex].Name !=
                    nombreColumnaEstado)
                    return;

                string estado = Convert.ToString(e.Value)?
                    .Trim()
                    .ToUpperInvariant() ?? string.Empty;

                Color fondo;
                Color texto;

                switch (estado)
                {
                    case "PENDIENTE":
                        fondo = Color.FromArgb(255, 248, 205);
                        texto = Color.FromArgb(120, 90, 0);
                        break;

                    case "RECHAZADO":
                        fondo = Color.FromArgb(255, 225, 225);
                        texto = Color.FromArgb(160, 30, 30);
                        break;

                    case "SIN_RESPUESTA":
                        fondo = Color.FromArgb(255, 235, 205);
                        texto = Color.FromArgb(155, 80, 0);
                        break;

                    case "EN_PROCESO":
                        fondo = Color.FromArgb(220, 238, 255);
                        texto = Color.FromArgb(20, 75, 145);
                        break;

                    case "AUTORIZADO":
                        fondo = Color.FromArgb(220, 245, 225);
                        texto = Color.FromArgb(25, 110, 45);
                        break;

                    default:
                        fondo = Color.White;
                        texto = Color.Black;
                        break;
                }

                e.CellStyle.BackColor = fondo;
                e.CellStyle.ForeColor = texto;

                // Mantenemos la selección azul del sistema.
                e.CellStyle.SelectionBackColor =
                    Color.FromArgb(0, 120, 215);

                e.CellStyle.SelectionForeColor = Color.White;
            };
        }


    }
}
