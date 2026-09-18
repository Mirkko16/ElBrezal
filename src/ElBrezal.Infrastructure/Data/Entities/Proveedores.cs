using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Proveedores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public int? LocalidadId { get; set; }

    public string? Telefono { get; set; }

    public string? CUIT { get; set; }

    public string? IngresosBrutos { get; set; }

    public string? Email { get; set; }

    public int? SituacionImpositivaId { get; set; }

    public string? Observacion { get; set; }

    public bool Eliminado { get; set; }

    public virtual Localidades? Localidad { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();

    public virtual SituacionesImpositivas? SituacionImpositiva { get; set; }
}
