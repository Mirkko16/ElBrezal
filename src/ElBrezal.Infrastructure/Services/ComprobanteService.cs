using ElBrezal.Application.Interfaces.Comprobantes;
using ElBrezal.Application.Models.Comprobantes;
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
            // Validaciones que no requieren consultar la base de datos.
            ValidarComprobante(dto);

            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                // Si existe un comprobante origen, validamos que:
                // - exista
                // - no esté anulado
                // - sea un presupuesto
                await ValidarComprobanteOrigenAsync(dto);

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

                    ComprobanteOrigenId = dto.ComprobanteOrigenId,

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

                // Aplica el movimiento definido por el tipo de comprobante.
                // Presupuesto: 0
                // Factura: -1
                // Nota de crédito: +1
                // Remito: -1
                await AplicarMovimientoStockAsync(dto);

                // En este SaveChanges se persisten:
                // - la actualización de UltimoNumero
                // - el encabezado del comprobante
                // - todos sus detalles
                // - el movimiento de stock
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

        public async Task<List<BuscarComprobanteDto>> BuscarAsync(string abreviaturaTipo, int? puntoVenta = null, int? numero = null)
        {
            var query = _context.Comprobantes
                .AsNoTracking()
                .Where(x =>
                    !x.Anulado &&
                    !x.TipoComprobante.Eliminado &&
                    x.TipoComprobante.Abreviatura == abreviaturaTipo);

            if (puntoVenta.HasValue)
            {
                query = query.Where(
                    x => x.PuntoVenta == puntoVenta.Value);
            }

            if (numero.HasValue)
            {
                query = query.Where(
                    x => x.Numero == numero.Value);
            }

            return await query
                .OrderByDescending(x => x.Fecha)
                .ThenByDescending(x => x.Numero)
                .Select(x => new BuscarComprobanteDto
                {
                    Id = x.Id,
                    TipoComprobanteId = x.TipoComprobanteId,
                    TipoComprobante = x.TipoComprobante.Nombre,
                    Abreviatura = x.TipoComprobante.Abreviatura,
                    PuntoVenta = x.PuntoVenta,
                    Numero = x.Numero,
                    Fecha = x.Fecha,
                    ClienteId = x.ClienteId,
                    Cliente = x.Cliente.Nombre,
                    Total = x.Total
                })
                .ToListAsync();
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

        public async Task<ComprobanteDto?> ObtenerPresupuestoAsync(int puntoVenta, int numero)
        {
            var presupuesto = await _context.Comprobantes
                .AsNoTracking()
                .Where(x =>
                    x.PuntoVenta == puntoVenta &&
                    x.Numero == numero &&
                    !x.Anulado &&
                    x.TipoComprobante.Abreviatura == "PRES")
                .Select(x => new ComprobanteDto
                {
                    Id = x.Id,
                    TipoComprobanteId = x.TipoComprobanteId,
                    PuntoVenta = x.PuntoVenta,
                    Numero = x.Numero,
                    Fecha = x.Fecha,
                    PorcentajeVariacion = x.PorcentajeVariacion,

                    ClienteId = x.ClienteId,
                    ClienteNombre = x.Cliente.Nombre,

                    Total = x.Total,
                    Anulado = x.Anulado,
                    VendedorId = x.VendedorId,
                    CondicionVentaId = x.CondicionVentaId,
                    SituacionImpositivaId = x.SituacionImpositivaId,

                    Subtotal = x.Subtotal,
                    MontoVariacion = x.MontoVariacion,
                    Observacion = x.Observacion,

                    Detalles = x.ComprobantesDetalle
                        .Select(d => new ComprobanteDetalleDto
                        {
                            ProductoId = d.ProductoId,
                            Descripcion = d.Descripcion,
                            Cantidad = d.Cantidad,
                            PrecioUnitario = d.PrecioUnitario,
                            Importe = d.Importe
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return presupuesto;
        }

        public async Task<ComprobanteDto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Comprobantes
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new ComprobanteDto
                {
                    Id = x.Id,
                    TipoComprobanteId = x.TipoComprobanteId,
                    PuntoVenta = x.PuntoVenta,
                    Numero = x.Numero,
                    Fecha = x.Fecha,

                    ClienteId = x.ClienteId,
                    ClienteNombre = x.Cliente.Nombre,

                    VendedorId = x.VendedorId,
                    CondicionVentaId = x.CondicionVentaId,
                    SituacionImpositivaId = x.SituacionImpositivaId,

                    PorcentajeVariacion = x.PorcentajeVariacion,
                    Subtotal = x.Subtotal,
                    MontoVariacion = x.MontoVariacion,
                    Total = x.Total,

                    Observacion = x.Observacion,
                    Anulado = x.Anulado,

                    Detalles = x.ComprobantesDetalle
                        .Select(d => new ComprobanteDetalleDto
                        {
                            ProductoId = d.ProductoId,
                            Descripcion = d.Descripcion,
                            Cantidad = d.Cantidad,
                            PrecioUnitario = d.PrecioUnitario,
                            Importe = d.Importe
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ComprobanteListadoDto>> ObtenerListadoAsync(int? tipoComprobanteId,DateTime fechaDesde,
                                                                            DateTime fechaHasta,int? clienteId = null)
        {
            var fechaHastaExclusive = fechaHasta.Date.AddDays(1);

            var query = _context.Comprobantes
                .AsNoTracking()
                .Where(x =>
                    x.Fecha >= fechaDesde.Date &&
                    x.Fecha < fechaHastaExclusive);

            if (tipoComprobanteId.HasValue)
            {
                query = query.Where(x =>
                    x.TipoComprobanteId == tipoComprobanteId.Value);
            }

            if (clienteId.HasValue)
            {
                query = query.Where(x =>
                    x.ClienteId == clienteId.Value);
            }

            return await query
                .OrderByDescending(x => x.Fecha)
                .ThenByDescending(x => x.Numero)
                .Select(x => new ComprobanteListadoDto
                {
                    Id = x.Id,
                    Fecha = x.Fecha,

                    TipoComprobanteId = x.TipoComprobanteId,
                    Tipo = x.TipoComprobante.Abreviatura ?? x.TipoComprobante.Nombre,

                    PuntoVenta = x.PuntoVenta,
                    Numero = x.Numero,

                    ClienteId = x.ClienteId,
                    Cliente = x.Cliente.Nombre,

                    Vendedor = x.Vendedor.Nombre,

                    CondicionVenta = x.CondicionVenta.Nombre,

                    Total = x.Total,
                    Anulado = x.Anulado
                })
                .ToListAsync();
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

        private async Task ValidarComprobanteOrigenAsync(CrearComprobanteDto dto)
        {
            if (!dto.ComprobanteOrigenId.HasValue)
                return;

            // =====================================================
            // COMPROBANTE ORIGEN
            // =====================================================

            var comprobanteOrigen = await _context.Comprobantes
                .AsNoTracking()
                .Include(x => x.TipoComprobante)
                .FirstOrDefaultAsync(x =>
                    x.Id == dto.ComprobanteOrigenId.Value);

            if (comprobanteOrigen is null)
            {
                throw new InvalidOperationException(
                    "El comprobante asociado no existe.");
            }

            if (comprobanteOrigen.Anulado)
            {
                throw new InvalidOperationException(
                    "El comprobante asociado se encuentra anulado.");
            }

            // =====================================================
            // TIPO DE COMPROBANTE DESTINO
            // =====================================================

            var tipoComprobanteDestino = await _context.TiposComprobante
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Id == dto.TipoComprobanteId &&
                    !x.Eliminado);

            if (tipoComprobanteDestino is null)
            {
                throw new InvalidOperationException(
                    "El tipo de comprobante seleccionado no existe.");
            }

            var abreviaturaOrigen =
                comprobanteOrigen.TipoComprobante.Abreviatura
                    .Trim()
                    .ToUpperInvariant();

            var abreviaturaDestino =
                tipoComprobanteDestino.Abreviatura
                    .Trim()
                    .ToUpperInvariant();

            // =====================================================
            // VALIDAR RELACIÓN ORIGEN → DESTINO
            // =====================================================

            var relacionValida =
                (abreviaturaOrigen == "PRES" &&
                    (abreviaturaDestino == "FA" ||
                     abreviaturaDestino == "FB" ||
                     abreviaturaDestino == "FC" ||
                     abreviaturaDestino == "REMI"))
                ||
                (abreviaturaOrigen == "REMI" &&
                    abreviaturaDestino == "DEVO")
                ||
                (abreviaturaOrigen == "FA" &&
                    abreviaturaDestino == "NCA")
                ||
                (abreviaturaOrigen == "FB" &&
                    abreviaturaDestino == "NCB")
                ||
                (abreviaturaOrigen == "FC" &&
                    abreviaturaDestino == "NCC");

            if (!relacionValida)
            {
                throw new InvalidOperationException(
                    $"No se puede asociar un comprobante " +
                    $"{abreviaturaOrigen} a un comprobante " +
                    $"{abreviaturaDestino}.");
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
