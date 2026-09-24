using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly ElBrezalDbContext _context;

        public VendedorService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<VendedorDto>> ObtenerTodosAsync()
        {
            return await _context.Vendedores
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new VendedorDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    LocalidadId = x.LocalidadId,
                    Localidad = x.Localidad != null
                        ? x.Localidad.Nombre
                        : null,
                    Email = x.Email
                })
                .ToListAsync();
        }

        public async Task<VendedorDto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Vendedores
                .AsNoTracking()
                .Where(x => x.Id == id && !x.Eliminado)
                .Select(x => new VendedorDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
                .FirstOrDefaultAsync();
        }

        public async Task AgregarAsync(VendedorDto vendedor)
        {
            var nuevoVendedor = new Vendedores
            {
                Nombre = vendedor.Nombre.Trim().ToUpperInvariant(),
                Direccion = NormalizarTexto(vendedor.Direccion),
                Telefono = NormalizarTexto(vendedor.Telefono),
                LocalidadId = vendedor.LocalidadId,
                Email = NormalizarEmail(vendedor.Email),
                Eliminado = false
            };

            _context.Vendedores.Add(nuevoVendedor);

            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(VendedorDto vendedor)
        {
            var vendedorDb = await _context.Vendedores
                .FirstOrDefaultAsync(x =>
                    x.Id == vendedor.Id &&
                    !x.Eliminado);

            if (vendedorDb is null)
                return;

            vendedorDb.Nombre = vendedor.Nombre.Trim().ToUpperInvariant();
            vendedorDb.Direccion = NormalizarTexto(vendedor.Direccion);
            vendedorDb.Telefono = NormalizarTexto(vendedor.Telefono);
            vendedorDb.LocalidadId = vendedor.LocalidadId;
            vendedorDb.Email = NormalizarEmail(vendedor.Email);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var vendedor = await _context.Vendedores
                .FirstOrDefaultAsync(x =>
                    x.Id == id &&
                    !x.Eliminado);

            if (vendedor is null)
                return;

            vendedor.Eliminado = true;

            await _context.SaveChangesAsync();
        }

        private static string? NormalizarTexto(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return null;

            return valor.Trim().ToUpperInvariant();
        }

        private static string? NormalizarEmail(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return null;

            return valor.Trim();
        }
    }
}