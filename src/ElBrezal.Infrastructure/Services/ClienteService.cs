using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElBrezal.Infrastructure.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ElBrezalDbContext _context;

        private static readonly Expression<Func<Clientes, ClienteDto>>
            ClienteDtoSelector = x => new ClienteDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                DNI = x.DNI,
                CUIT = x.CUIT,
                IngresosBrutos = x.IngresosBrutos,
                Direccion = x.Direccion,

                LocalidadId = x.LocalidadId,
                Localidad = x.Localidad.Nombre,
                CodigoPostal = x.Localidad.CodigoPostal,
                Provincia = x.Localidad.Provincia.Nombre,

                Telefono = x.Telefono,
                Email = x.Email,

                SituacionImpositivaId = x.SituacionImpositivaId,
                SituacionImpositiva = x.SituacionImpositiva.Nombre,

                EstadoCuentaId = x.EstadoCuentaId,
                EstadoCuenta = x.EstadoCuenta.Nombre,

                VendedorId = x.VendedorId,
                Vendedor = x.Vendedor != null
                    ? x.Vendedor.Nombre
                    : null,

                Observacion = x.Observacion
            };

        public ClienteService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteDto>> ObtenerTodosAsync()
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(ClienteDtoSelector)
                .ToListAsync();
        }

        public async Task<ClienteDto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Clientes
                .AsNoTracking()
                .Where(x => x.Id == id && !x.Eliminado)
                .Select(ClienteDtoSelector)
                .FirstOrDefaultAsync();
        }

        public async Task AgregarAsync(ClienteDto cliente)
        {
            var nuevoCliente = new Clientes
            {
                Nombre = cliente.Nombre.Trim().ToUpperInvariant(),

                DNI = NormalizarTexto(cliente.DNI),
                CUIT = NormalizarTexto(cliente.CUIT),
                IngresosBrutos = NormalizarTexto(cliente.IngresosBrutos),

                Direccion = NormalizarTexto(cliente.Direccion),

                LocalidadId = cliente.LocalidadId,

                Telefono = NormalizarTexto(cliente.Telefono),

                Email = string.IsNullOrWhiteSpace(cliente.Email)
                    ? null
                    : cliente.Email.Trim(),

                SituacionImpositivaId = cliente.SituacionImpositivaId,
                EstadoCuentaId = cliente.EstadoCuentaId,
                VendedorId = cliente.VendedorId,

                Observacion = NormalizarTexto(cliente.Observacion),

                Eliminado = false
            };

            _context.Clientes.Add(nuevoCliente);

            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(ClienteDto cliente)
        {
            var clienteDb = await _context.Clientes
                .FirstOrDefaultAsync(
                    x => x.Id == cliente.Id && !x.Eliminado);

            if (clienteDb is null)
                return;

            clienteDb.Nombre =
                cliente.Nombre.Trim().ToUpperInvariant();

            clienteDb.DNI =
                NormalizarTexto(cliente.DNI);

            clienteDb.CUIT =
                NormalizarTexto(cliente.CUIT);

            clienteDb.IngresosBrutos =
                NormalizarTexto(cliente.IngresosBrutos);

            clienteDb.Direccion =
                NormalizarTexto(cliente.Direccion);

            clienteDb.LocalidadId =
                cliente.LocalidadId;

            clienteDb.Telefono =
                NormalizarTexto(cliente.Telefono);

            clienteDb.Email =
                string.IsNullOrWhiteSpace(cliente.Email)
                    ? null
                    : cliente.Email.Trim();

            clienteDb.SituacionImpositivaId =
                cliente.SituacionImpositivaId;

            clienteDb.EstadoCuentaId =
                cliente.EstadoCuentaId;

            clienteDb.VendedorId =
                cliente.VendedorId;

            clienteDb.Observacion =
                NormalizarTexto(cliente.Observacion);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(
                    x => x.Id == id && !x.Eliminado);

            if (cliente is null)
                return;

            cliente.Eliminado = true;

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