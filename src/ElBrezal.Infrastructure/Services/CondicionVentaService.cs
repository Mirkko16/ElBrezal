using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class CondicionVentaService : ICondicionVentaService
    {
        private readonly ElBrezalDbContext _context;

        public CondicionVentaService(
            ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<CondicionVentaDto>> ObtenerTodasAsync()
        {
            return await _context.CondicionesVenta
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Id)
                .Select(x => new CondicionVentaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
                .ToListAsync();
        }
    }
}