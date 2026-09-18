using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Clientes
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? DNI { get; set; }

    public string? CUIT { get; set; }

    public string? IngresosBrutos { get; set; }

    public string? Direccion { get; set; }

    public int LocalidadId { get; set; }

    public string? Telefono1 { get; set; }

    public string? Telefono2 { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? Ocupacion { get; set; }

    public string? Matricula { get; set; }

    public int SituacionImpositivaId { get; set; }

    public int EstadoCuentaId { get; set; }

    public int? VendedorId { get; set; }

    public string? Observacion { get; set; }

    public bool Eliminado { get; set; }

    public virtual EstadosCuentaCliente EstadoCuenta { get; set; } = null!;

    public virtual Localidades Localidad { get; set; } = null!;

    public virtual SituacionesImpositivas SituacionImpositiva { get; set; } = null!;

    public virtual Vendedores? Vendedor { get; set; }
}
