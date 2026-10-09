using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Comprobantes
{
    public class ComprobanteListadoDto
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int TipoComprobanteId { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public int PuntoVenta { get; set; }

        public int Numero { get; set; }

        public int ClienteId { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public string Vendedor { get; set; } = string.Empty;

        public string CondicionVenta { get; set; } = string.Empty;

        public decimal Total { get; set; }

        public bool Anulado { get; set; }
    }
}
