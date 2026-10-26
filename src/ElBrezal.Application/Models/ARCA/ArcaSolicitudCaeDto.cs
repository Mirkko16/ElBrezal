using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ArcaSolicitudCaeDto
    {
        public int PuntoVenta { get; set; }
        public int TipoComprobante { get; set; }
        public long Numero { get; set; }

        public DateOnly Fecha { get; set; }

        public int Concepto { get; set; } = 1;

        public int DocTipo { get; set; }
        public long DocNro { get; set; }

        public int CondicionIvaReceptorId { get; set; }

        public decimal ImporteTotal { get; set; }
        public decimal ImporteNeto { get; set; }
        public decimal ImporteNoGravado { get; set; }
        public decimal ImporteExento { get; set; }
        public decimal ImporteIVA { get; set; }
        public decimal ImporteTributos { get; set; }

        public List<ArcaAlicuotaIvaDto> AlicuotasIVA { get; set; } = new();
    }

    public class ArcaAlicuotaIvaDto
    {
        public int Id { get; set; }
        public decimal BaseImponible { get; set; }
        public decimal Importe { get; set; }
    }
}
