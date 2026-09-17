using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly ElBrezalDbContext _context;

        public ProveedorService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProveedorDto>> ObtenerTodosAsync()
        {
            return await _context.Proveedores
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new ProveedorDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,

                    LocalidadId = x.LocalidadId,
                    Localidad = x.Localidad != null
                        ? x.Localidad.Nombre
                        : null,
                    CodigoPostal = x.Localidad != null
                        ? x.Localidad.CodigoPostal
                        : null,
                    Provincia = x.Localidad != null
                        ? x.Localidad.Provincia.Nombre
                        : null,

                    Telefono = x.Telefono,

                    CUIT = x.CUIT,
                    IngresosBrutos = x.IngresosBrutos,
                    Email = x.Email,

                    SituacionImpositivaId = x.SituacionImpositivaId,
                    SituacionImpositiva = x.SituacionImpositiva != null
                        ? x.SituacionImpositiva.Nombre
                        : null,

                    Observacion = x.Observacion
                })
                .ToListAsync();
        }

        public async Task AgregarAsync(ProveedorDto proveedor)
        {
            var nuevoProveedor = new Proveedores
            {
                Nombre = proveedor.Nombre.Trim().ToUpperInvariant(),

                Direccion = NormalizarTexto(proveedor.Direccion),
                LocalidadId = proveedor.LocalidadId,

                Telefono = NormalizarTexto(proveedor.Telefono),

                CUIT = NormalizarTexto(proveedor.CUIT),
                IngresosBrutos = NormalizarTexto(proveedor.IngresosBrutos),

                Email = string.IsNullOrWhiteSpace(proveedor.Email)
                    ? null
                    : proveedor.Email.Trim(),

                SituacionImpositivaId = proveedor.SituacionImpositivaId,

                Observacion = NormalizarTexto(proveedor.Observacion),

                Eliminado = false
            };

            _context.Proveedores.Add(nuevoProveedor);

            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(ProveedorDto proveedor)
        {
            var proveedorDb = await _context.Proveedores
                .FirstOrDefaultAsync(x =>
                    x.Id == proveedor.Id &&
                    !x.Eliminado);

            if (proveedorDb is null)
                return;

            proveedorDb.Nombre = proveedor.Nombre.Trim().ToUpperInvariant();

            proveedorDb.Direccion = NormalizarTexto(proveedor.Direccion);
            proveedorDb.LocalidadId = proveedor.LocalidadId;

            proveedorDb.Telefono = NormalizarTexto(proveedor.Telefono);

            proveedorDb.CUIT = NormalizarTexto(proveedor.CUIT);
            proveedorDb.IngresosBrutos = NormalizarTexto(proveedor.IngresosBrutos);

            proveedorDb.Email = string.IsNullOrWhiteSpace(proveedor.Email)
                ? null
                : proveedor.Email.Trim();

            proveedorDb.SituacionImpositivaId = proveedor.SituacionImpositivaId;

            proveedorDb.Observacion = NormalizarTexto(proveedor.Observacion);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(x =>
                    x.Id == id &&
                    !x.Eliminado);

            if (proveedor is null)
                return;

            proveedor.Eliminado = true;

            await _context.SaveChangesAsync();
        }

        private static string? NormalizarTexto(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return null;

            return valor.Trim().ToUpperInvariant();
        }
    }
}