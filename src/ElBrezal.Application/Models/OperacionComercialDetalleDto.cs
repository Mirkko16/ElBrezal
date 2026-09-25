using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models
{
    public class OperacionComercialDetalleDto
    {
        public int ProductoId { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Importe { get; set; }
    }
}
