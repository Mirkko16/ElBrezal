using ElBrezal.Application.ActualizacionCostos;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services;

public class ActualizacionCostosService : IActualizacionCostosService
{
    private readonly ElBrezalDbContext _context;

    public ActualizacionCostosService(ElBrezalDbContext context)
    {
        _context = context;
    }

    public async Task<List<ActualizacionCostoProductoDto>> BuscarProductosAsync(
        int? familiaId,
        int? marcaId,
        int? proveedorId)
    {
        var query = _context.Productos
            .AsNoTracking()
            .Where(x => !x.Eliminado);

        if (familiaId.HasValue)
            query = query.Where(x => x.FamiliaId == familiaId.Value);

        if (marcaId.HasValue)
            query = query.Where(x => x.MarcaId == marcaId.Value);

        if (proveedorId.HasValue)
            query = query.Where(x => x.ProveedorId == proveedorId.Value);

        return await query
            .OrderBy(x => x.Nombre)
            .Select(x => new ActualizacionCostoProductoDto
            {
                Seleccionado = true,
                Id = x.Id,
                Codigo = x.Id.ToString(),
                Nombre = x.Nombre,

                Familia = x.Familia != null
                    ? x.Familia.Nombre
                    : string.Empty,

                Marca = x.Marca != null
                    ? x.Marca.Nombre
                    : string.Empty,

                Proveedor = x.Proveedor != null
                    ? x.Proveedor.Nombre
                    : string.Empty,

                Costo = x.Costo,

                RentabilidadContado = x.RentabilidadContado,
                PrecioContado = x.PrecioContado,

                RentabilidadReventa = x.RentabilidadReventa,
                PrecioReventa = x.PrecioReventa,

                RentabilidadCuentaCorriente =
                    x.RentabilidadCuentaCorriente,

                PrecioCuentaCorriente =
                    x.PrecioCuentaCorriente
            })
            .ToListAsync();
    }

    public async Task AplicarActualizacionAsync(
        IEnumerable<int> productosIds,
        TipoActualizacionCosto tipoActualizacion,
        decimal valor)
    {
        var ids = productosIds
            .Distinct()
            .ToList();

        if (ids.Count == 0)
            return;

        if (valor <= 0)
        {
            throw new ArgumentException(
                "El valor de actualización debe ser mayor a cero.",
                nameof(valor));
        }

        var productos = await _context.Productos
            .Where(x =>
                ids.Contains(x.Id) &&
                !x.Eliminado)
            .ToListAsync();

        foreach (var producto in productos)
        {
            switch (tipoActualizacion)
            {
                case TipoActualizacionCosto.Porcentaje:
                    AplicarPorcentaje(producto, valor);
                    break;

                case TipoActualizacionCosto.Importe:
                    AplicarImporte(producto, valor);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(tipoActualizacion));
            }

            producto.FechaModificacion = DateTime.Now;
        }

        await _context.SaveChangesAsync();
    }

    private static void AplicarPorcentaje(
        Productos producto,
        decimal porcentaje)
    {
        producto.RentabilidadContado += porcentaje;
        producto.RentabilidadReventa += porcentaje;
        producto.RentabilidadCuentaCorriente += porcentaje;

        producto.PrecioContado =
            CalcularPrecio(
                producto.Costo,
                producto.RentabilidadContado);

        producto.PrecioReventa =
            CalcularPrecio(
                producto.Costo,
                producto.RentabilidadReventa);

        producto.PrecioCuentaCorriente =
            CalcularPrecio(
                producto.Costo,
                producto.RentabilidadCuentaCorriente);
    }

    private static void AplicarImporte(
        Productos producto,
        decimal importe)
    {
        producto.PrecioContado += importe;
        producto.PrecioReventa += importe;
        producto.PrecioCuentaCorriente += importe;

        producto.RentabilidadContado =
            CalcularRentabilidad(
                producto.Costo,
                producto.PrecioContado);

        producto.RentabilidadReventa =
            CalcularRentabilidad(
                producto.Costo,
                producto.PrecioReventa);

        producto.RentabilidadCuentaCorriente =
            CalcularRentabilidad(
                producto.Costo,
                producto.PrecioCuentaCorriente);
    }

    private static decimal CalcularPrecio(
        decimal costo,
        decimal rentabilidad)
    {
        return costo + (costo * rentabilidad / 100m);
    }

    private static decimal CalcularRentabilidad(
        decimal costo,
        decimal precio)
    {
        if (costo == 0)
            return 0;

        return ((precio - costo) / costo) * 100m;
    }
}