using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class TiposComprobante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public short Signo { get; set; }

    public short MovimientoStock { get; set; }

    public bool Eliminado { get; set; }
}
