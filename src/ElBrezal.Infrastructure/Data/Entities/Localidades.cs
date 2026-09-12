using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Localidades
{
    public int Id { get; set; }

    public string? CodigoPostal { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Provincia { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Vendedores> Vendedores { get; set; } = new List<Vendedores>();
}
