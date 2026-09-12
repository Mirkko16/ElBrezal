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
    public class MarcaService : IMarcaService
    {
        private readonly ElBrezalDbContext _context;

        public MarcaService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<MarcaDto>> ObtenerTodasAsync()
        {
            return await _context.Marcas
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new MarcaDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
                .ToListAsync();
        }

        public async Task AgregarAsync(string nombre)
        {
            var marca = new Marcas
            {
                Nombre = nombre.Trim(),
                Eliminado = false
            };

            _context.Marcas.Add(marca);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var marca = await _context.Marcas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (marca is null)
                return;

            marca.Eliminado = true;

            await _context.SaveChangesAsync();
        }
    }
}
