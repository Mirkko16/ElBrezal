using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class EstadosCuentaCliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Clientes> Clientes { get; set; } = new List<Clientes>();
}
