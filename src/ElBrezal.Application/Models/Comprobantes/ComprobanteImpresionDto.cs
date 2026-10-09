using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Comprobantes
{
    public class ComprobanteImpresionDto
    {
        // Identificación
        public int Id { get; set; }
        public string TipoComprobante { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;
        public int PuntoVenta { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }

        // Cliente
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;
        public string ClienteDireccion { get; set; } = string.Empty;
        public string ClienteTelefono { get; set; } = string.Empty;
        public string ClienteDNI { get; set; } = string.Empty;
        public string ClienteCUIT { get; set; } = string.Empty;

        // Datos comerciales
        public string Vendedor { get; set; } = string.Empty;
        public string CondicionVenta { get; set; } = string.Empty;
        public string SituacionImpositiva { get; set; } = string.Empty;

        // Importes
        public decimal PorcentajeVariacion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal MontoVariacion { get; set; }
        public decimal Total { get; set; }

        public string? Observacion { get; set; }

        // Productos
        public List<ComprobanteImpresionDetalleDto> Detalles { get; set; } = new();
    }

    public class ComprobanteImpresionDetalleDto
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
    }
}
