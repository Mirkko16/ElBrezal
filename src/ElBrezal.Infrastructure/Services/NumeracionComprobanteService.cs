using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Interfaces.ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class NumeracionComprobanteService
        : INumeracionComprobanteService
    {
        private readonly ElBrezalDbContext _context;

        public NumeracionComprobanteService(
            ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<NumeracionComprobanteDto>> ObtenerTodosAsync()
        {
            return await _context.NumeracionesComprobante
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.TipoComprobanteId)
                .ThenBy(x => x.PuntoVenta)
                .Select(x => new NumeracionComprobanteDto
                {
                    Id = x.Id,
                    TipoComprobanteId = x.TipoComprobanteId,
                    PuntoVenta = x.PuntoVenta,
                    UltimoNumero = x.UltimoNumero
                })
                .ToListAsync();
        }

        public async Task<NumeracionComprobanteDto?>
            ObtenerPorTipoYPuntoVentaAsync(
                int tipoComprobanteId,
                int puntoVenta)
        {
            return await _context.NumeracionesComprobante
                .AsNoTracking()
                .Where(x =>
                    x.TipoComprobanteId == tipoComprobanteId &&
                    x.PuntoVenta == puntoVenta &&
                    !x.Eliminado)
                .Select(x => new NumeracionComprobanteDto
                {
                    Id = x.Id,
                    TipoComprobanteId = x.TipoComprobanteId,
                    PuntoVenta = x.PuntoVenta,
                    UltimoNumero = x.UltimoNumero
                })
                .FirstOrDefaultAsync();
        }
    }
}