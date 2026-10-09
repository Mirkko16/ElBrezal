using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Estadisticas
{
    public class VentaArticuloValorizadaDto
    {
        public int ProductoId { get; set; }

        public string Articulo { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public decimal Total { get; set; }
    }
}
