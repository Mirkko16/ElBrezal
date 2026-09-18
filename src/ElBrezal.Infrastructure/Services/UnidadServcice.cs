using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Infrastructure.Services
{
    public class UnidadService : IUnidadService
    {
        private readonly ElBrezalDbContext _context;

        public UnidadService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<UnidadDto>> ObtenerTodasAsync()
        {
            return await _context.Unidades
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Descripcion)
                .Select(x => new UnidadDto
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion
                })
                .ToListAsync();
        }

        public async Task AgregarAsync(string descripcion)
        {
            var unidad = new Unidades
            {
                Descripcion = descripcion.Trim(),
                Eliminado = false
            };

            _context.Unidades.Add(unidad);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var unidad = await _context.Unidades
                .FirstOrDefaultAsync(x => x.Id == id);

            if (unidad is null)
                return;

            unidad.Eliminado = true;

            await _context.SaveChangesAsync();
        }
    }
}
