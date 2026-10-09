using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Comprobantes
{
    public class ComprobanteCreadoDto
    {
        public int Id { get; set; }

        public int TipoComprobanteId { get; set; }

        public int PuntoVenta { get; set; }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }
    }
}
