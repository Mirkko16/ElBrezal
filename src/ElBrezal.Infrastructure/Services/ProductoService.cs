using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ElBrezalDbContext _context;

        public ProductoService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoDto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .AsNoTracking()
                .Where(x => !x.Eliminado)
                .OrderBy(x => x.Nombre)
                .Select(x => new ProductoDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,

                    FamiliaId = x.FamiliaId,
                    Familia = x.Familia != null
                        ? x.Familia.Nombre
                        : null,

                    MarcaId = x.MarcaId,
                    Marca = x.Marca != null
                        ? x.Marca.Nombre
                        : null,

                    UnidadId = x.UnidadId,
                    Unidad = x.Unidad != null
                        ? x.Unidad.Descripcion
                        : null,

                    ProveedorId = x.ProveedorId,
                    Proveedor = x.Proveedor != null
                        ? x.Proveedor.Nombre
                        : null,

                    Costo = x.Costo,
                    AlicuotaIVAId = x.AlicuotaIVAId,
                    AlicuotaIVA = x.AlicuotaIVA.Nombre,
                    PorcentajeIVA = x.AlicuotaIVA.Porcentaje,

                    RentabilidadContado = x.RentabilidadContado,
                    PrecioContado = x.PrecioContado,

                    RentabilidadReventa = x.RentabilidadReventa,
                    PrecioReventa = x.PrecioReventa,

                    RentabilidadCuentaCorriente = x.RentabilidadCuentaCorriente,
                    PrecioCuentaCorriente = x.PrecioCuentaCorriente,

                    Stock = x.Stock,
                    StockMinimo = x.StockMinimo,

                    FechaAlta = x.FechaAlta,
                    FechaModificacion = x.FechaModificacion
                })
                .ToListAsync();
        }

        public async Task AgregarAsync(ProductoDto producto)
        {
            var nuevoProducto = new Productos
            {
                Nombre = producto.Nombre.Trim().ToUpperInvariant(),

                FamiliaId = producto.FamiliaId,
                MarcaId = producto.MarcaId,
                UnidadId = producto.UnidadId,
                ProveedorId = producto.ProveedorId,

                Costo = producto.Costo,
                AlicuotaIVAId = producto.AlicuotaIVAId,

                RentabilidadContado = producto.RentabilidadContado,
                PrecioContado = producto.PrecioContado,

                RentabilidadReventa = producto.RentabilidadReventa,
                PrecioReventa = producto.PrecioReventa,

                RentabilidadCuentaCorriente =
                    producto.RentabilidadCuentaCorriente,

                PrecioCuentaCorriente =
                    producto.PrecioCuentaCorriente,

                Stock = producto.Stock,
                StockMinimo = producto.StockMinimo,

                FechaAlta = DateTime.Now,
                FechaModificacion = null,
                Eliminado = false
            };

            _context.Productos.Add(nuevoProducto);

            await _context.SaveChangesAsync();
        }

        public async Task<ProductoDto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos
                .AsNoTracking()
                .Where(x => x.Id == id && !x.Eliminado)
                .Select(x => new ProductoDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,

                    // mismos campos de ObtenerTodosAsync
                    PrecioContado = x.PrecioContado,
                    Stock = x.Stock

                    // etc.
                })
                .FirstOrDefaultAsync();
        }

        public async Task ModificarAsync(ProductoDto producto)
        {
            var productoDb = await _context.Productos
                .FirstOrDefaultAsync(x =>
                    x.Id == producto.Id &&
                    !x.Eliminado);

            if (productoDb is null)
                return;

            productoDb.Nombre =
                producto.Nombre.Trim().ToUpperInvariant();

            productoDb.FamiliaId = producto.FamiliaId;
            productoDb.MarcaId = producto.MarcaId;
            productoDb.UnidadId = producto.UnidadId;
            productoDb.ProveedorId = producto.ProveedorId;

            productoDb.Costo = producto.Costo;
            productoDb.AlicuotaIVAId = producto.AlicuotaIVAId;

            productoDb.RentabilidadContado =
                producto.RentabilidadContado;

            productoDb.PrecioContado =
                producto.PrecioContado;

            productoDb.RentabilidadReventa =
                producto.RentabilidadReventa;

            productoDb.PrecioReventa =
                producto.PrecioReventa;

            productoDb.RentabilidadCuentaCorriente =
                producto.RentabilidadCuentaCorriente;

            productoDb.PrecioCuentaCorriente =
                producto.PrecioCuentaCorriente;

            productoDb.Stock = producto.Stock;
            productoDb.StockMinimo = producto.StockMinimo;

            productoDb.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductoDto>> ObtenerConStockMinimoAsync()
        {
            return await _context.Productos
                .AsNoTracking()
                .Where(x =>
                    !x.Eliminado &&
                    x.StockMinimo > 0 &&
                    x.Stock <= x.StockMinimo)
                .OrderBy(x => x.Nombre)
                .Select(x => new ProductoDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Stock = x.Stock,
                    StockMinimo = x.StockMinimo
                })
                .ToListAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(x =>
                    x.Id == id &&
                    !x.Eliminado);

            if (producto is null)
                return;

            producto.Eliminado = true;
            producto.FechaModificacion = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}