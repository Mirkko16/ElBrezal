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
    public class FamiliaService : IFamiliaService
    {
        private readonly ElBrezalDbContext _context;

        public FamiliaService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<FamiliaDto>> ObtenerTodasAsync()
        {
            return await _context.Familias
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new FamiliaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
                .ToListAsync();
        }

        public async Task AgregarAsync(string nombre)
        {
            var familia = new Familias
            {
                Nombre = nombre.Trim(),
                Eliminado = false
            };

            _context.Familias.Add(familia);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var familia = await _context.Familias
                .FirstOrDefaultAsync(x => x.Id == id);

            if (familia is null)
                return;

            familia.Eliminado = true;

            await _context.SaveChangesAsync();
        }
    }
}
