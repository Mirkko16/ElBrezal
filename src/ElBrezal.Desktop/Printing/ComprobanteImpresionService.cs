
using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Interfaces.Comprobantes;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElBrezal.Desktop.Printing
{
    public class ComprobanteImpresionService
    {
        private readonly IComprobanteService _comprobanteService;
        private readonly ComprobantePdfGenerator _pdfGenerator;

        public ComprobanteImpresionService(
            IComprobanteService comprobService,
            ComprobantePdfGenerator pdfGenerator)
        {
            _comprobanteService = comprobService;
            _pdfGenerator = pdfGenerator;
        }

        public async Task<string> GenerarPdfAsync(int comprobanteId)
        {
            var comprobante =
                await _comprobanteService.ObtenerParaImpresionAsync(comprobanteId);

            if (comprobante is null)
            {
                throw new InvalidOperationException(
                    "No se encontró el comprobante solicitado.");
            }

            var pdf = _pdfGenerator.Generar(comprobante);

            var carpeta = Path.Combine(
                Path.GetTempPath(),
                "ElBrezal",
                "Comprobantes");

            Directory.CreateDirectory(carpeta);

            var nombreArchivo =
                $"{comprobante.Abreviatura}_" +
                $"{comprobante.PuntoVenta:0000}-" +
                $"{comprobante.Numero:000000}.pdf";

            var rutaArchivo = Path.Combine(
                carpeta,
                nombreArchivo);

            await File.WriteAllBytesAsync(rutaArchivo, pdf);

            return rutaArchivo;
        }

        public async Task AbrirVistaPreviaAsync(int comprobanteId)
        {
            var rutaArchivo =
                await GenerarPdfAsync(comprobanteId);

            Process.Start(new ProcessStartInfo
            {
                FileName = rutaArchivo,
                UseShellExecute = true
            });
        }

        public async Task PreguntarImpresionAsync(int comprobanteId, string tipoComprobante, int puntoVenta, int numero, IWin32Window propietario)
        {
            var respuesta = MessageBox.Show(
                propietario,
                $"{tipoComprobante} guardado correctamente.\n\n" +
                $"Número: {puntoVenta:0000}-{numero:000000}\n\n" +
                "¿Desea imprimir el comprobante?",
                tipoComprobante,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                await AbrirVistaPreviaAsync(comprobanteId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    propietario,
                    $"El {tipoComprobante.ToLowerInvariant()} " +
                    "se guardó correctamente, pero no fue posible " +
                    "abrir el PDF.\n\n" +
                    ex.Message,
                    "Error de impresión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
