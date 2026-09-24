using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class TipoComprobanteDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Abreviatura { get; set; }

        public short Signo { get; set; }

        public short MovimientoStock { get; set; }
    }
}
