using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Models;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace ElBrezal.Infrastructure.Services
{
    public class ComprobanteService : IComprobanteService
    {
        private readonly ElBrezalDbContext _context;

        public ComprobanteService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<ComprobanteCreadoDto> CrearAsync(CrearComprobanteDto dto)
        {
            ValidarComprobante(dto);

            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                // Si es un cliente existente devuelve su Id.
                // Si es un alta rápida (9999), crea el cliente dentro
                // de esta misma transacción y devuelve el Id generado.
                var clienteId = await ObtenerClienteIdAsync(dto);

                // Bloqueamos la fila de numeración hasta finalizar la transacción.
                // De esta forma dos terminales no pueden obtener simultáneamente
                // el mismo número de comprobante.
                var numeracion = await _context.NumeracionesComprobante
                    .FromSqlInterpolated($@"
                SELECT *
                FROM NumeracionesComprobante WITH (UPDLOCK, ROWLOCK)
                WHERE TipoComprobanteId = {dto.TipoComprobanteId}
                  AND PuntoVenta = {dto.PuntoVenta}
                  AND Eliminado = 0")
                    .FirstOrDefaultAsync();

                if (numeracion is null)
                {
                    throw new InvalidOperationException(
                        "No existe una numeración configurada para el tipo de comprobante y punto de venta seleccionados.");
                }

                var numero = numeracion.UltimoNumero + 1;

                numeracion.UltimoNumero = numero;

                var comprobante = new Comprobantes
                {
                    TipoComprobanteId = dto.TipoComprobanteId,
                    PuntoVenta = dto.PuntoVenta,
                    Numero = numero,
                    Fecha = dto.Fecha,

                    ClienteId = clienteId,
                    VendedorId = dto.VendedorId,
                    CondicionVentaId = dto.CondicionVentaId,
                    SituacionImpositivaId = dto.SituacionImpositivaId,

                    PorcentajeVariacion = dto.PorcentajeVariacion,
                    Subtotal = dto.Subtotal,
                    MontoVariacion = dto.MontoVariacion,
                    Total = dto.Total,

                    Observacion = NormalizarTexto(dto.Observacion),

                    Anulado = false,
                    CreatedAt = DateTime.Now
                };

                foreach (var detalle in dto.Detalles)
                {
                    comprobante.ComprobantesDetalle.Add(
                        new ComprobantesDetalle
                        {
                            ProductoId = detalle.ProductoId,

                            Descripcion = detalle.Descripcion
                                .Trim()
                                .ToUpperInvariant(),

                            Cantidad = detalle.Cantidad,
                            PrecioUnitario = detalle.PrecioUnitario,
                            Importe = detalle.Importe
                        });
                }

                _context.Comprobantes.Add(comprobante);

                // En este SaveChanges se persisten:
                // - la actualización de UltimoNumero
                // - el encabezado del comprobante
                // - todos sus detalles
                await AplicarMovimientoStockAsync(dto);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new ComprobanteCreadoDto
                {
                    Id = comprobante.Id,
                    TipoComprobanteId = comprobante.TipoComprobanteId,
                    PuntoVenta = comprobante.PuntoVenta,
                    Numero = comprobante.Numero,
                    Fecha = comprobante.Fecha,
                    Total = comprobante.Total
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        private async Task<int> ObtenerClienteIdAsync(CrearComprobanteDto dto)
        {
            if (dto.ClienteId.HasValue)
            {
                var existe = await _context.Clientes
                    .AnyAsync(x =>
                        x.Id == dto.ClienteId.Value &&
                        !x.Eliminado);

                if (!existe)
                {
                    throw new InvalidOperationException(
                        "El cliente seleccionado no existe.");
                }

                return dto.ClienteId.Value;
            }

            if (dto.ClienteRapido is null)
            {
                throw new InvalidOperationException(
                    "Debe seleccionar o ingresar un cliente.");
            }

            var cliente = dto.ClienteRapido;

            var nuevoCliente = new Clientes
            {
                Nombre = cliente.Nombre.Trim().ToUpperInvariant(),
                DNI = NormalizarTexto(cliente.DNI),
                CUIT = NormalizarTexto(cliente.CUIT),
                Direccion = NormalizarTexto(cliente.Direccion),
                Telefono = NormalizarTexto(cliente.Telefono),

                LocalidadId = cliente.LocalidadId,
                SituacionImpositivaId = cliente.SituacionImpositivaId,
                EstadoCuentaId = cliente.EstadoCuentaId,
                VendedorId = cliente.VendedorId,

                Eliminado = false
            };

            _context.Clientes.Add(nuevoCliente);

            // Necesitamos el IDENTITY antes de crear Comprobantes.
            await _context.SaveChangesAsync();

            return nuevoCliente.Id;
        }

        private static void ValidarComprobante( CrearComprobanteDto dto)
        {
            if (dto.TipoComprobanteId <= 0)
                throw new InvalidOperationException(
                    "Debe seleccionar un tipo de comprobante.");

            if (dto.PuntoVenta <= 0)
                throw new InvalidOperationException(
                    "El punto de venta no es válido.");

            if (dto.VendedorId <= 0)
                throw new InvalidOperationException(
                    "Debe seleccionar un vendedor.");

            if (dto.CondicionVentaId <= 0)
                throw new InvalidOperationException(
                    "Debe seleccionar una condición de venta.");

            if (dto.SituacionImpositivaId <= 0)
                throw new InvalidOperationException(
                    "Debe seleccionar una situación impositiva.");

            if (dto.Detalles.Count == 0)
                throw new InvalidOperationException(
                    "El comprobante debe contener al menos un artículo.");

            if (dto.Detalles.Any(x =>
                x.ProductoId <= 0 ||
                x.Cantidad <= 0 ||
                x.PrecioUnitario < 0))
            {
                throw new InvalidOperationException(
                    "Existen artículos con datos inválidos.");
            }

            if (!dto.ClienteId.HasValue && dto.ClienteRapido is null)
            {
                throw new InvalidOperationException(
                    "Debe seleccionar o ingresar un cliente.");
            }

            if (dto.ClienteId.HasValue && dto.ClienteRapido is not null)
            {
                throw new InvalidOperationException(
                    "El comprobante no puede contener simultáneamente un cliente existente y un alta rápida.");
            }
        }

        private static string? NormalizarTexto(string? valor)
        {
            return string.IsNullOrWhiteSpace(valor)
                ? null
                : valor.Trim().ToUpperInvariant();
        }

        private async Task AplicarMovimientoStockAsync(CrearComprobanteDto dto)
        {
            var tipoComprobante = await _context.TiposComprobante
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Id == dto.TipoComprobanteId &&
                    !x.Eliminado);

            if (tipoComprobante is null)
            {
                throw new InvalidOperationException(
                    "El tipo de comprobante seleccionado no existe.");
            }

            // Este tipo de comprobante no afecta stock.
            // Ejemplo: Presupuesto.
            if (tipoComprobante.MovimientoStock == 0)
                return;

            var productosIds = dto.Detalles
                .Select(x => x.ProductoId)
                .Distinct()
                .ToList();

            var productos = await _context.Productos
                .Where(x =>
                    productosIds.Contains(x.Id) &&
                    !x.Eliminado)
                .ToDictionaryAsync(x => x.Id);

            foreach (var detalle in dto.Detalles)
            {
                if (!productos.TryGetValue(
                        detalle.ProductoId,
                        out var producto))
                {
                    throw new InvalidOperationException(
                        $"El producto N° {detalle.ProductoId} no existe.");
                }

                var movimiento =
                    detalle.Cantidad * tipoComprobante.MovimientoStock;

                producto.Stock += movimiento;
            }
        }
    }
}
