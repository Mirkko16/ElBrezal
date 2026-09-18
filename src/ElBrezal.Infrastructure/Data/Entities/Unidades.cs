using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Unidades
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Eliminado { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
