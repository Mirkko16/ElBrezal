
using ElBrezal.Application.Models.Comprobantes;
using Microsoft.Extensions.Configuration;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ElBrezal.Desktop.Printing
{
    public class ComprobantePdfGenerator
    {
        private readonly IConfiguration _configuration;

        private static readonly CultureInfo Cultura =
            CultureInfo.GetCultureInfo("es-AR");

        public ComprobantePdfGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public byte[] Generar(ComprobanteImpresionDto comprobante)
        {
            ArgumentNullException.ThrowIfNull(comprobante);

            var logo = CargarLogo();

            return Document.Create(document =>
            {
                CrearCopia(document, comprobante, "ORIGINAL", logo);
                CrearCopia(document, comprobante, "DUPLICADO", logo);
            }).GeneratePdf();
        }

        private byte[]? CargarLogo()
        {
            var rutaRelativa =
                _configuration["Empresa:LogoPath"];

            if (string.IsNullOrWhiteSpace(rutaRelativa))
                return null;

            var rutaCompleta = Path.GetFullPath(
                Path.Combine(
                    AppContext.BaseDirectory,
                    rutaRelativa));

            if (!File.Exists(rutaCompleta))
            {
                throw new FileNotFoundException(
                    "No se encontró el logo configurado para El Brezal.",
                    rutaCompleta);
            }

            return File.ReadAllBytes(rutaCompleta);
        }

        private void CrearCopia(
            IDocumentContainer document,
            ComprobanteImpresionDto comprobante,
            string copia,
            byte[]? logo)
        {
            var nombreEmpresa =
                _configuration["Empresa:Nombre"] ?? "El Brezal";

            var nombreComercial =
                _configuration["Empresa:NombreComercial"] ?? "CORRALÓN";

            var domicilio =
                _configuration["Empresa:Domicilio"] ?? string.Empty;

            var localidad =
                _configuration["Empresa:Localidad"] ?? string.Empty;

            var provincia =
                _configuration["Empresa:Provincia"] ?? string.Empty;

            var telefono =
                _configuration["Empresa:Telefono"] ?? string.Empty;

            var abreviatura =
                comprobante.Abreviatura.Trim().ToUpperInvariant();

            var esRemito =
                abreviatura == "REMI" || abreviatura == "DEVO";

            var seccion =
                abreviatura == "PRES"
                    ? "Presupuesto"
                    : esRemito
                        ? "Remito"
                        : null;

            var letra = seccion is null
                ? string.Empty
                : _configuration[$"Impresion:{seccion}:Letra"]
                    ?? "X";

            var leyenda = seccion is null
                ? string.Empty
                : _configuration[$"Impresion:{seccion}:Leyenda"]
                    ?? "Documento no válido como factura";

            var condicionesEntrega = esRemito
                ? _configuration
                    .GetSection("Impresion:Remito:CondicionesEntrega")
                    .Get<string[]>() ?? Array.Empty<string>()
                : Array.Empty<string>();

            document.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(15, Unit.Millimetre);

                page.DefaultTextStyle(x =>
                    x.FontFamily("Courier New").FontSize(9));

                // ==========================================
                // ENCABEZADO
                // ==========================================

                page.Header().Column(column =>
                {
                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Column(empresa =>
                        {
                            if (logo is not null)
                            {
                                empresa.Item()
                                    .Height(65)
                                    .Image(logo)
                                    .FitArea();
                            }
                            else
                            {
                                empresa.Item()
                                    .Text(nombreEmpresa)
                                    .Bold()
                                    .FontSize(24);
                            }

                            empresa.Item()
                                .Text(nombreComercial)
                                .Bold()
                                .FontSize(11);

                            if (!string.IsNullOrWhiteSpace(domicilio))
                            {
                                empresa.Item()
                                    .Text(domicilio)
                                    .FontSize(8);
                            }

                            empresa.Item()
                                .Text($"{localidad} - {provincia}")
                                .FontSize(8);

                            if (!string.IsNullOrWhiteSpace(telefono))
                            {
                                empresa.Item()
                                    .Text($"TEL: {telefono}")
                                    .FontSize(8);
                            }
                        });

                        row.ConstantItem(190)
                            .AlignRight()
                            .Column(datos =>
                            {
                                if (!string.IsNullOrWhiteSpace(letra))
                                {
                                    datos.Item()
                                        .AlignRight()
                                        .Text(letra)
                                        .Bold()
                                        .FontSize(22);
                                }

                                if (!string.IsNullOrWhiteSpace(leyenda))
                                {
                                    datos.Item()
                                        .AlignRight()
                                        .Text(leyenda)
                                        .FontSize(7);
                                }

                                datos.Item()
                                    .AlignRight()
                                    .Text(comprobante.TipoComprobante)
                                    .Bold()
                                    .FontSize(12);

                                datos.Item()
                                    .AlignRight()
                                    .Text(
                                        $"{comprobante.PuntoVenta:0000}-" +
                                        $"{comprobante.Numero:000000}");

                                datos.Item()
                                    .AlignRight()
                                    .Text(
                                        comprobante.Fecha.ToString(
                                            "dd/MM/yyyy"));

                                datos.Item()
                                    .AlignRight()
                                    .Text(copia)
                                    .Bold();
                            });
                    });

                    column.Item()
                        .PaddingVertical(8)
                        .LineHorizontal(1);

                    // ==========================================
                    // DATOS DEL CLIENTE
                    // ==========================================

                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Column(cliente =>
                        {
                            cliente.Item().Text(
                                $"CLIENTE: {comprobante.ClienteNombre}");

                            cliente.Item().Text(
                                $"DIRECCIÓN: {comprobante.ClienteDireccion}");

                            cliente.Item().Text(
                                $"TELÉFONO: {comprobante.ClienteTelefono}");

                            cliente.Item().Text(
                                $"CUIT: {comprobante.ClienteCUIT}");
                        });

                        row.RelativeItem().Column(comercial =>
                        {
                            comercial.Item().Text(
                                $"CUENTA: {comprobante.ClienteId}");

                            comercial.Item().Text(
                                $"COND. IVA: {comprobante.SituacionImpositiva}");

                            comercial.Item().Text(
                                $"COND. VENTA: {comprobante.CondicionVenta}");

                            comercial.Item().Text(
                                $"VENDEDOR: {comprobante.Vendedor}");
                        });
                    });

                    column.Item()
                        .PaddingVertical(8)
                        .LineHorizontal(1);
                });

                // ==========================================
                // DETALLE Y TOTALES
                // ==========================================

                page.Content().Column(column =>
                {
                    column.Spacing(12);

                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(55);
                            columns.RelativeColumn(5);
                            columns.ConstantColumn(85);
                            columns.ConstantColumn(90);
                        });

                        table.Header(header =>
                        {
                            header.Cell()
                                .Text("CANT.")
                                .Bold();

                            header.Cell()
                                .Text("ARTÍCULO")
                                .Bold();

                            header.Cell()
                                .AlignRight()
                                .Text("PRECIO")
                                .Bold();

                            header.Cell()
                                .AlignRight()
                                .Text("IMPORTE")
                                .Bold();
                        });

                        foreach (var detalle in comprobante.Detalles)
                        {
                            table.Cell().Text(
                                detalle.Cantidad.ToString("N2", Cultura));

                            table.Cell().Text(
                                $"{detalle.ProductoId} {detalle.Descripcion}");

                            table.Cell().AlignRight().Text(
                                detalle.PrecioUnitario.ToString("N2", Cultura));

                            table.Cell().AlignRight().Text(
                                detalle.Importe.ToString("N2", Cultura));
                        }
                    });

                    column.Item()
                        .PaddingTop(15)
                        .Column(totales =>
                        {
                            totales.Item()
                                .AlignRight()
                                .Text(
                                    $"SUBTOTAL: $ " +
                                    comprobante.Subtotal.ToString("N2", Cultura));

                            totales.Item()
                                .AlignRight()
                                .Text(
                                    $"VARIACIÓN " +
                                    $"({comprobante.PorcentajeVariacion.ToString("N2", Cultura)}%): " +
                                    $"$ {comprobante.MontoVariacion.ToString("N2", Cultura)}");

                            totales.Item()
                                .AlignRight()
                                .Text(
                                    $"TOTAL: $ " +
                                    comprobante.Total.ToString("N2", Cultura))
                                .Bold()
                                .FontSize(12);
                        });

                    column.Item().Text(
                        $"OBSERVACIONES: {comprobante.Observacion ?? "-"}");

                    // ==========================================
                    // RECEPCIÓN DE MERCADERÍA
                    // ==========================================

                    if (esRemito)
                    {
                        column.Item()
                            .PaddingTop(30)
                            .Column(firma =>
                            {
                                firma.Item()
                                    .Text("RECIBÍ CONFORME:");

                                firma.Item()
                                    .PaddingTop(25)
                                    .Text(
                                        "FIRMA: ____________________    " +
                                        "ACLARACIÓN: ____________________");

                                firma.Item()
                                    .Text(
                                        "D.N.I.: ____________________");
                            });
                    }
                });

                // ==========================================
                // PIE DE PÁGINA
                // ==========================================

                page.Footer().Column(footer =>
                {
                    footer.Item().LineHorizontal(0.5f);

                    if (esRemito)
                    {
                        foreach (var condicion in condicionesEntrega)
                        {
                            footer.Item()
                                .PaddingTop(2)
                                .Text(condicion)
                                .FontSize(7);
                        }
                    }

                    footer.Item()
                        .PaddingTop(5)
                        .AlignRight()
                        .Text(text =>
                        {
                            text.Span($"{copia} - Página ");
                            text.CurrentPageNumber();
                        });
                });
            });
        }
    }
}
