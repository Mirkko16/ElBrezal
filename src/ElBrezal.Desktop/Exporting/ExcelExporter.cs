using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Desktop.Exporting
{
    public static class ExcelExporter
    {
        public static void Exportar<T>(
            string rutaArchivo,
            IEnumerable<T> datos,
            string titulo,
            string? subtitulo,
            IReadOnlyList<ExcelColumn<T>> columnas,
            string? tituloTotal = null,
            decimal? total = null)
        {
            var listaDatos = datos.ToList();

            using var workbook = new XLWorkbook();

            var worksheet =
                workbook.Worksheets.Add("Datos");

            int filaActual = 1;

            // =====================================================
            // TÍTULO
            // =====================================================

            var celdaTitulo =
                worksheet.Cell(filaActual, 1);

            celdaTitulo.Value = titulo;

            worksheet.Range(
                    filaActual,
                    1,
                    filaActual,
                    columnas.Count)
                .Merge();

            celdaTitulo.Style.Font.Bold = true;
            celdaTitulo.Style.Font.FontSize = 16;
            celdaTitulo.Style.Alignment.Horizontal =
                XLAlignmentHorizontalValues.Center;

            filaActual++;

            // =====================================================
            // SUBTÍTULO
            // =====================================================

            if (!string.IsNullOrWhiteSpace(subtitulo))
            {
                var celdaSubtitulo =
                    worksheet.Cell(filaActual, 1);

                celdaSubtitulo.Value = subtitulo;

                worksheet.Range(
                        filaActual,
                        1,
                        filaActual,
                        columnas.Count)
                    .Merge();

                celdaSubtitulo.Style.Font.Bold = true;

                celdaSubtitulo.Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                filaActual++;
            }

            // Dejamos una fila libre.
            filaActual++;

            // =====================================================
            // ENCABEZADOS
            // =====================================================

            int filaEncabezado = filaActual;

            for (int columna = 0;
                 columna < columnas.Count;
                 columna++)
            {
                var celda =
                    worksheet.Cell(
                        filaEncabezado,
                        columna + 1);

                celda.Value =
                    columnas[columna].Titulo;

                celda.Style.Font.Bold = true;

                celda.Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                celda.Style.Border.BottomBorder =
                    XLBorderStyleValues.Thin;

                celda.Style.Border.TopBorder =
                    XLBorderStyleValues.Thin;
            }

            filaActual++;

            // =====================================================
            // DATOS
            // =====================================================

            foreach (var item in listaDatos)
            {
                for (int columna = 0;
                     columna < columnas.Count;
                     columna++)
                {
                    var definicion =
                        columnas[columna];

                    var valor =
                        definicion.Valor(item);

                    var celda =
                        worksheet.Cell(
                            filaActual,
                            columna + 1);

                    AsignarValor(celda, valor);

                    if (!string.IsNullOrWhiteSpace(
                            definicion.Formato))
                    {
                        celda.Style.NumberFormat.Format =
                            definicion.Formato;
                    }
                }

                filaActual++;
            }

            // =====================================================
            // TOTAL
            // =====================================================

            if (total.HasValue &&
                columnas.Count > 0)
            {
                filaActual++;

                if (columnas.Count > 1)
                {
                    var rangoDescripcion =
                        worksheet.Range(
                            filaActual,
                            1,
                            filaActual,
                            columnas.Count - 1);

                    rangoDescripcion.Merge();

                    rangoDescripcion.Value =
                        string.IsNullOrWhiteSpace(tituloTotal)
                            ? "TOTAL"
                            : tituloTotal;

                    rangoDescripcion.Style.Font.Bold = true;

                    rangoDescripcion.Style.Alignment.Horizontal =
                        XLAlignmentHorizontalValues.Right;
                }

                var celdaTotal =
                    worksheet.Cell(
                        filaActual,
                        columnas.Count);

                celdaTotal.Value = total.Value;

                celdaTotal.Style.Font.Bold = true;

                celdaTotal.Style.NumberFormat.Format =
                    "$ #,##0.00";

                celdaTotal.Style.Border.TopBorder =
                    XLBorderStyleValues.Thin;
            }

            // =====================================================
            // FILTRO
            // =====================================================

            if (listaDatos.Count > 0)
            {
                int ultimaFilaDatos =
                    filaEncabezado + listaDatos.Count;

                worksheet.Range(
                        filaEncabezado,
                        1,
                        ultimaFilaDatos,
                        columnas.Count)
                    .SetAutoFilter();
            }

            // =====================================================
            // PRESENTACIÓN
            // =====================================================

            worksheet.SheetView.FreezeRows(
                filaEncabezado);

            worksheet.Columns()
                .AdjustToContents();

            // Evitamos columnas exageradamente anchas por textos largos.
            foreach (var columna in worksheet.ColumnsUsed())
            {
                if (columna.Width > 50)
                {
                    columna.Width = 50;
                }
            }

            workbook.SaveAs(rutaArchivo);
        }

        private static void AsignarValor(
            IXLCell celda,
            object? valor)
        {
            if (valor is null)
            {
                celda.Value = string.Empty;
                return;
            }

            switch (valor)
            {
                case int numero:
                    celda.Value = numero;
                    break;

                case long numero:
                    celda.Value = numero;
                    break;

                case decimal numero:
                    celda.Value = numero;
                    break;

                case double numero:
                    celda.Value = numero;
                    break;

                case float numero:
                    celda.Value = numero;
                    break;

                case DateTime fecha:
                    celda.Value = fecha;
                    break;

                case bool booleano:
                    celda.Value = booleano;
                    break;

                default:
                    celda.Value =
                        valor.ToString() ?? string.Empty;
                    break;
            }
        }
    }
}
