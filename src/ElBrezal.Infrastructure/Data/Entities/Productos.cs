using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Productos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? FamiliaId { get; set; }

    public int? MarcaId { get; set; }

    public int? UnidadId { get; set; }

    public int? ProveedorId { get; set; }

    public decimal Costo { get; set; }

    public decimal RentabilidadContado { get; set; }

    public decimal PrecioContado { get; set; }

    public decimal RentabilidadReventa { get; set; }

    public decimal PrecioReventa { get; set; }

    public decimal RentabilidadCuentaCorriente { get; set; }

    public decimal PrecioCuentaCorriente { get; set; }

    public decimal Stock { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool Eliminado { get; set; }

    public int AlicuotaIVAId { get; set; }

    public decimal StockMinimo { get; set; }

    public virtual AlicuotasIVA AlicuotaIVA { get; set; } = null!;

    public virtual Familias? Familia { get; set; }

    public virtual Marcas? Marca { get; set; }

    public virtual Proveedores? Proveedor { get; set; }

    public virtual Unidades? Unidad { get; set; }
}
