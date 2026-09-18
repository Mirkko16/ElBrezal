using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class LocalidadService : ILocalidadService
    {
        private readonly ElBrezalDbContext _context;

        public LocalidadService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocalidadDto>> ObtenerTodasAsync()
        {
            return await _context.Localidades
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new LocalidadDto
                {
                    Id = x.Id,
                    CodigoPostal = x.CodigoPostal,
                    Nombre = x.Nombre,
                    ProvinciaId = x.ProvinciaId,
                    Provincia = x.Provincia.Nombre
                })
                .ToListAsync();
        }

        public async Task AgregarAsync(
            string nombre,
            string codigoPostal,
            int provinciaId)
        {
            var localidad = new Localidades
            {
                Nombre = nombre.Trim().ToUpperInvariant(),
                CodigoPostal = codigoPostal.Trim().ToUpperInvariant(),
                ProvinciaId = provinciaId,
                Eliminado = false
            };

            _context.Localidades.Add(localidad);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var localidad = await _context.Localidades
                .FirstOrDefaultAsync(x => x.Id == id);

            if (localidad is null)
                return;

            localidad.Eliminado = true;

            await _context.SaveChangesAsync();
        }
        public async Task ModificarAsync( int id, string nombre, string codigoPostal, int provinciaId)
        {
            var localidad = await _context.Localidades
                .FirstOrDefaultAsync(x => x.Id == id);

            if (localidad is null)
                return;

            localidad.Nombre = nombre.Trim().ToUpperInvariant();
            localidad.CodigoPostal = codigoPostal.Trim().ToUpperInvariant();
            localidad.ProvinciaId = provinciaId;

            await _context.SaveChangesAsync();
        }
    }
}