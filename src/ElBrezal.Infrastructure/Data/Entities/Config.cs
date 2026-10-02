using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Config
{
    public int Id { get; set; }

    public string Clave { get; set; } = null!;

    public string? Valor { get; set; }

    public string? Descripcion { get; set; }
}
