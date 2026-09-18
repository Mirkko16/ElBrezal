using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.ActualizacionCostos
{
    public class ActualizacionCostoProductoDto
    {
        public bool Seleccionado { get; set; } = true;

        public int Id { get; set; }

        public string Codigo { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Familia { get; set; } = string.Empty;

        public string Marca { get; set; } = string.Empty;

        public string Proveedor { get; set; } = string.Empty;

        public decimal Costo { get; set; }

        public decimal RentabilidadContado { get; set; }

        public decimal PrecioContado { get; set; }

        public decimal RentabilidadReventa { get; set; }

        public decimal PrecioReventa { get; set; }

        public decimal RentabilidadCuentaCorriente { get; set; }

        public decimal PrecioCuentaCorriente { get; set; }
    }
}
