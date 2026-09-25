using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class OperacionComercialDto
    {
        public int TipoComprobanteId { get; set; }

        public int PuntoVenta { get; set; }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public ClienteDto? Cliente { get; set; }

        public VendedorDto? Vendedor { get; set; }

        public int? CondicionVentaId { get; set; }

        public decimal Variacion { get; set; }

        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public string? Observacion { get; set; }

        public List<OperacionComercialDetalleDto> Detalles { get; set; } = new();
    }
}
