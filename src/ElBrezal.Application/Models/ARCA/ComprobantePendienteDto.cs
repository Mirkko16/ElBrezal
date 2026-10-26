using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    public class ComprobantePendienteDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public string TipoComprobante { get; set; } = "";
        public int PuntoVenta { get; set; }
        public long Numero { get; set; }

        public string Cliente { get; set; } = "";
        public decimal Total { get; set; }

        public string Estado { get; set; } = "";
        public string? UltimoError { get; set; }

        public int CantidadIntentos { get; set; }
        public DateTime? UltimoIntento { get; set; }

        public bool PuedeAutorizar =>
            Estado is "PENDIENTE" or "RECHAZADO";

        public bool RequiereConsulta =>
            Estado is "EN_PROCESO" or "SIN_RESPUESTA";
    }
}