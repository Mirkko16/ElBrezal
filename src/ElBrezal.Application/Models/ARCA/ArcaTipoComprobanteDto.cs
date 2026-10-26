using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ArcaTipoComprobanteDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string? FechaDesde { get; set; }
        public string? FechaHasta { get; set; }
    }
}
