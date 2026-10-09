using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Comprobantes
{
    public class BuscarComprobanteDto
    {
        public int Id { get; set; }

        public int TipoComprobanteId { get; set; }

        public string TipoComprobante { get; set; } = string.Empty;

        public string Abreviatura { get; set; } = string.Empty;

        public int PuntoVenta { get; set; }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public decimal Total { get; set; }
    }
}
