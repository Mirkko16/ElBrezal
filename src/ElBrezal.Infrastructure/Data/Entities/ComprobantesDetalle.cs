using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class ComprobantesDetalle
{
    public int Id { get; set; }

    public int ComprobanteId { get; set; }

    public int ProductoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Importe { get; set; }

    public virtual Comprobantes Comprobante { get; set; } = null!;

    public virtual Productos Producto { get; set; } = null!;
}
