using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class ArcaCredenciales
{
    public int Id { get; set; }

    public long CUIT { get; set; }

    public string Ambiente { get; set; } = null!;

    public string Servicio { get; set; } = null!;

    public byte[] TokenProtegido { get; set; } = null!;

    public byte[] SignProtegido { get; set; } = null!;

    public DateTimeOffset FechaExpiracion { get; set; }

    public DateTime UpdatedAt { get; set; }
}
