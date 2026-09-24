using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Infrastructure.Services
{
    public class TipoComprobanteService : ITipoComprobanteService
    {
        private readonly ElBrezalDbContext _context;

        public TipoComprobanteService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoComprobanteDto>> ObtenerTodosAsync()
        {
            return await _context.TiposComprobante
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Id)
                .Select(x => new TipoComprobanteDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Abreviatura = x.Abreviatura,
                    Signo = x.Signo,
                    MovimientoStock = x.MovimientoStock
                })
                .ToListAsync();
        }
    }
}
