using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class AlicuotaIVAService : IAlicuotaIVAService
    {
        private readonly ElBrezalDbContext _context;

        public AlicuotaIVAService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlicuotaIVADto>> ObtenerTodasAsync()
        {
            return await _context.AlicuotasIVA
                .AsNoTracking()
                .OrderBy(x => x.Porcentaje)
                .Select(x => new AlicuotaIVADto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Porcentaje = x.Porcentaje
                })
                .ToListAsync();
        }
    }
}