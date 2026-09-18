using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly ElBrezalDbContext _context;

        public ProvinciaService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProvinciaDto>> ObtenerTodasAsync()
        {
            return await _context.Provincias
                .AsNoTracking()
                .OrderBy(x => x.Nombre)
                .Select(x => new ProvinciaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
                .ToListAsync();
        }
    }
}