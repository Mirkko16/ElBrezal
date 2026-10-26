using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ArcaPuntoVentaDto
    {
        public int Numero { get; set; }
        public string TipoEmision { get; set; } = string.Empty;
        public string Bloqueado { get; set; } = string.Empty;
        public string? FechaBaja { get; set; }
    }
}
