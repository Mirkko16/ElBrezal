using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class NumeracionComprobanteDto
    {
        public int Id { get; set; }

        public int TipoComprobanteId { get; set; }

        public int PuntoVenta { get; set; }

        public int UltimoNumero { get; set; }

        public int ProximoNumero => UltimoNumero + 1;

        public string ProximoNumeroFormateado =>
            $"{PuntoVenta:0000}-{ProximoNumero:000000}";
    }
}
