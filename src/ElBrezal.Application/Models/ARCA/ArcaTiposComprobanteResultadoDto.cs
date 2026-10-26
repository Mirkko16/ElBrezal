using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ArcaTiposComprobanteResultadoDto
    {
        public List<ArcaTipoComprobanteDto> TiposComprobante { get; set; } = new();
        public List<string> Observaciones { get; set; } = new();
    }
}
