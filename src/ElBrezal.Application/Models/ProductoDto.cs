using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int? FamiliaId { get; set; }
        public string? Familia { get; set; }

        public int? MarcaId { get; set; }
        public string? Marca { get; set; }

        public int? UnidadId { get; set; }
        public string? Unidad { get; set; }

        public int? ProveedorId { get; set; }
        public string? Proveedor { get; set; }

        public decimal Costo { get; set; }

        public int AlicuotaIVAId { get; set; }
        public string AlicuotaIVA { get; set; } = string.Empty;
        public decimal PorcentajeIVA { get; set; }

        public decimal RentabilidadContado { get; set; }
        public decimal PrecioContado { get; set; }

        public decimal RentabilidadReventa { get; set; }
        public decimal PrecioReventa { get; set; }

        public decimal RentabilidadCuentaCorriente { get; set; }
        public decimal PrecioCuentaCorriente { get; set; }

        public decimal Stock { get; set; }

        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
