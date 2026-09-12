using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Familias
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? Porcentaje { get; set; }

    public bool Eliminado { get; set; }
}
