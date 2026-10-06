using ElBrezal.Application.Models;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Printing
{
    public class ComprobantesListadoPrinter
    {
        private readonly List<ComprobanteListadoDto> _comprobantes;

        private readonly string _tipoComprobante;
        private readonly DateTime _fechaDesde;
        private readonly DateTime _fechaHasta;
        private readonly string _cliente;

        private readonly PrintDocument _printDocument;

        private int _filaImpresion;
        private decimal _totalImpresion;

        public ComprobantesListadoPrinter(
            List<ComprobanteListadoDto> comprobantes,
            string tipoComprobante,
            DateTime fechaDesde,
            DateTime fechaHasta,
            string cliente)
        {
            _comprobantes = comprobantes;
            _tipoComprobante = tipoComprobante;
            _fechaDesde = fechaDesde;
            _fechaHasta = fechaHasta;
            _cliente = cliente;

            _printDocument = new PrintDocument();

            _printDocument.DefaultPageSettings.Landscape = true;

            _printDocument.DefaultPageSettings.Margins =
                new Margins(40, 40, 40, 40);

            _printDocument.PrintPage += PrintDocument_PrintPage;
        }

        public void MostrarVistaPrevia(IWin32Window owner)
        {
            if (_comprobantes.Count == 0)
                return;

            _filaImpresion = 0;
            _totalImpresion =
                _comprobantes.Sum(x => x.Total);

            using var vistaPrevia = new PrintPreviewDialog
            {
                Document = _printDocument,
                Width = 1100,
                Height = 750
            };

            vistaPrevia.ShowDialog(owner);
        }

        private void PrintDocument_PrintPage(
            object? sender,
            PrintPageEventArgs e)
        {
            var graphics = e.Graphics;

            if (graphics is null)
                return;

            var area = e.MarginBounds;

            using var fuenteTitulo =
                new Font("Segoe UI", 14F, FontStyle.Bold);

            using var fuenteSubtitulo =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            using var fuenteEncabezado =
                new Font("Segoe UI", 8F, FontStyle.Bold);

            using var fuenteDatos =
                new Font("Courier New", 8F, FontStyle.Regular);

            using var fuenteTotal =
                new Font("Courier New", 9F, FontStyle.Bold);

            using var lapiz =
                new Pen(Color.Black);

            using var formatoCentro = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using var formatoIzquierda = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };

            using var formatoDerecha = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };

            float x = area.Left;
            float y = area.Top;
            float anchoTotal = area.Width;

            // ====================================================
            // TÍTULO
            // ====================================================

            var rectTitulo =
                new RectangleF(
                    x,
                    y,
                    anchoTotal,
                    30);

            graphics.DrawString(
                "LISTADO DE COMPROBANTES",
                fuenteTitulo,
                Brushes.Black,
                rectTitulo,
                formatoCentro);

            y += 35;

            // ====================================================
            // FILTROS
            // ====================================================

            graphics.DrawString(
                $"Tipo: {_tipoComprobante}",
                fuenteSubtitulo,
                Brushes.Black,
                x,
                y);

            graphics.DrawString(
                $"Desde: {_fechaDesde:dd/MM/yyyy}",
                fuenteSubtitulo,
                Brushes.Black,
                x + 300,
                y);

            graphics.DrawString(
                $"Hasta: {_fechaHasta:dd/MM/yyyy}",
                fuenteSubtitulo,
                Brushes.Black,
                x + 500,
                y);

            y += 20;

            graphics.DrawString(
                $"Cliente: {_cliente}",
                fuenteSubtitulo,
                Brushes.Black,
                x,
                y);

            y += 25;

            // ====================================================
            // COLUMNAS
            // ====================================================

            var anchos = new[]
            {
                anchoTotal * 0.09F, // Fecha
                anchoTotal * 0.06F, // Tipo
                anchoTotal * 0.13F, // Número
                anchoTotal * 0.07F, // Cuenta
                anchoTotal * 0.25F, // Cliente
                anchoTotal * 0.14F, // Vendedor
                anchoTotal * 0.13F, // Condición
                anchoTotal * 0.13F  // Total
            };

            var titulos = new[]
            {
                "Fecha",
                "Tipo",
                "Número",
                "Cuenta",
                "Cliente",
                "Vendedor",
                "Condición",
                "Total"
            };

            const float alturaEncabezado = 24F;
            const float alturaFila = 20F;

            float columnaX = x;

            for (int i = 0; i < titulos.Length; i++)
            {
                var rect =
                    new RectangleF(
                        columnaX,
                        y,
                        anchos[i],
                        alturaEncabezado);

                graphics.DrawRectangle(
                    lapiz,
                    rect.X,
                    rect.Y,
                    rect.Width,
                    rect.Height);

                graphics.DrawString(
                    titulos[i],
                    fuenteEncabezado,
                    Brushes.Black,
                    rect,
                    formatoCentro);

                columnaX += anchos[i];
            }

            y += alturaEncabezado;

            // ====================================================
            // FILAS
            // ====================================================

            while (_filaImpresion < _comprobantes.Count)
            {
                var comprobante =
                    _comprobantes[_filaImpresion];

                // Reservamos espacio para el pie.
                if (y + alturaFila > area.Bottom - 45)
                {
                    e.HasMorePages = true;
                    return;
                }

                var valores = new[]
                {
                    comprobante.Fecha.ToString("dd/MM/yyyy"),

                    comprobante.Tipo,

                    $"{comprobante.PuntoVenta:0000}-" +
                    $"{comprobante.Numero:000000}",

                    comprobante.ClienteId.ToString(),

                    comprobante.Cliente,

                    comprobante.Vendedor,

                    comprobante.CondicionVenta,

                    comprobante.Total.ToString("N2")
                };

                columnaX = x;

                for (int i = 0; i < valores.Length; i++)
                {
                    var rect =
                        new RectangleF(
                            columnaX,
                            y,
                            anchos[i],
                            alturaFila);

                    graphics.DrawRectangle(
                        lapiz,
                        rect.X,
                        rect.Y,
                        rect.Width,
                        rect.Height);

                    var formato =
                        i == 7
                            ? formatoDerecha
                            : i == 3
                                ? formatoDerecha
                                : i == 4 || i == 5 || i == 6
                                    ? formatoIzquierda
                                    : formatoCentro;

                    var rectTexto =
                        new RectangleF(
                            rect.X + 3,
                            rect.Y,
                            rect.Width - 6,
                            rect.Height);

                    graphics.DrawString(
                        valores[i],
                        fuenteDatos,
                        Brushes.Black,
                        rectTexto,
                        formato);

                    columnaX += anchos[i];
                }

                y += alturaFila;

                _filaImpresion++;
            }

            // ====================================================
            // TOTAL
            // ====================================================

            y += 10;

            graphics.DrawLine(
                lapiz,
                x,
                y,
                x + anchoTotal,
                y);

            y += 8;

            graphics.DrawString(
                $"TOTAL: {_totalImpresion:N2}",
                fuenteTotal,
                Brushes.Black,
                new RectangleF(
                    x,
                    y,
                    anchoTotal,
                    22),
                formatoDerecha);

            y += 22;

            graphics.DrawString(
                $"Cantidad de comprobantes: {_comprobantes.Count}",
                fuenteDatos,
                Brushes.Black,
                x,
                y);

            e.HasMorePages = false;

            // La impresión terminó.
            _filaImpresion = 0;
        }
    }
}