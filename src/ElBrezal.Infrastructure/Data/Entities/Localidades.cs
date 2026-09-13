using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Localidades
{
    public int Id { get; set; }

    public string CodigoPostal { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool Eliminado { get; set; }

    public int ProvinciaId { get; set; }

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();

    public virtual Provincias Provincia { get; set; } = null!;

    public virtual ICollection<Vendedores> Vendedores { get; set; } = new List<Vendedores>();
}
