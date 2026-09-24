using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class SituacionesImpositivas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Abreviatura { get; set; }

    public bool Eliminado { get; set; }

    public decimal Porce { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual ICollection<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
}
