using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class ComprobanteDto
    {
        public int Id { get; set; }
        public int TipoComprobanteId { get; set; }
        public int PuntoVenta { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }       
        public decimal PorcentajeVariacion { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;
        public decimal Total { get; set; }

        public bool Anulado { get; set; }

        public List<ComprobanteDetalleDto> Detalles { get; set; } = new();
    }

}
