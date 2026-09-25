using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class NumeracionesComprobante
{
    public int Id { get; set; }

    public int TipoComprobanteId { get; set; }

    public int PuntoVenta { get; set; }

    public int UltimoNumero { get; set; }

    public bool Eliminado { get; set; }

    public virtual TiposComprobante TipoComprobante { get; set; } = null!;
}
