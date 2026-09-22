using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class CondicionesVenta
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Eliminado { get; set; }
}
