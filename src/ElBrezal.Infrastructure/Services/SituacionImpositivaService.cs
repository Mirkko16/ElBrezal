using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class SituacionImpositivaService : ISituacionImpositivaService
    {
        private readonly ElBrezalDbContext _context;

        public SituacionImpositivaService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<SituacionImpositivaDto>> ObtenerTodasAsync()
        {
            return await _context.SituacionesImpositivas
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new SituacionImpositivaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Abreviatura = x.Abreviatura
                })
                .ToListAsync();
        }
    }
}
