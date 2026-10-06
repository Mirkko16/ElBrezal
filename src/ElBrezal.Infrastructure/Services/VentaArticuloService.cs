using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Infrastructure.Services
{
    public class VentaArticuloService : IVentaArticuloService
    {
        private readonly ElBrezalDbContext _context;

        public VentaArticuloService(
            ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<VentaArticuloValorizadaDto>> ObtenerValorizadasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            var desde = fechaDesde.Date;
            var hastaExclusive = fechaHasta.Date.AddDays(1);

            var tiposIncluidos = new[]
            { "FA", "FB", "REMI", "NCA", "NCB" };

            var resultado =
                await _context.ComprobantesDetalle
                    .AsNoTracking()
                    .Where(x =>
                        x.Comprobante.Fecha >= desde &&
                        x.Comprobante.Fecha < hastaExclusive &&
                        !x.Comprobante.Anulado &&
                        tiposIncluidos.Contains(
                            x.Comprobante.TipoComprobante.Abreviatura))
                    .GroupBy(x => new
                    {
                        x.ProductoId,
                        x.Producto.Nombre
                    })
                    .Select(g => new VentaArticuloValorizadaDto
                    {
                        ProductoId = g.Key.ProductoId,

                        Articulo = g.Key.Nombre,

                        Cantidad = g.Sum(x =>
                            x.Cantidad *
                            x.Comprobante.TipoComprobante.Signo),

                        Total = g.Sum(x =>
                            x.Importe *
                            x.Comprobante.TipoComprobante.Signo)
                    })
                    .OrderBy(x => x.ProductoId)
                    .ToListAsync();

            return resultado;
        }
    }
}
