using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Provincias
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Localidades> Localidades { get; set; } = new List<Localidades>();
}
