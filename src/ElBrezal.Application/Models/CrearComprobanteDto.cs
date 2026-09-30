using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class CrearComprobanteDto
    {
        public int TipoComprobanteId { get; set; }

        public int PuntoVenta { get; set; }

        public DateTime Fecha { get; set; }

        public int? ClienteId { get; set; }

        public ClienteRapidoDto? ClienteRapido { get; set; }

        public int VendedorId { get; set; }

        public int CondicionVentaId { get; set; }

        public int SituacionImpositivaId { get; set; }

        public decimal PorcentajeVariacion { get; set; }

        public decimal Subtotal { get; set; }

        public decimal MontoVariacion { get; set; }

        public decimal Total { get; set; }

        public string? Observacion { get; set; }

        public List<ComprobanteDetalleDto> Detalles { get; set; } = new();
    }
}
