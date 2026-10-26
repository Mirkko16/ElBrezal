using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ArcaPuntosVentaResultadoDto
    {
        public List<ArcaPuntoVentaDto> PuntosVenta { get; set; } = new();
        public List<string> Observaciones { get; set; } = new();
    }
}
