using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Comprobantes
{
    public class ComprobanteDetalleDto
    {
        public int ProductoId { get; set; }

        public string Descripcion { get; set; } = string.Empty;

        public decimal Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Importe { get; set; }

        /// <summary>
        /// Identificador de la alícuota aplicada al producto.
        /// </summary>
        public int? AlicuotaIVAId { get; set; }

        /// <summary>
        /// Porcentaje de IVA aplicado al momento de la operación.
        /// </summary>
        public decimal? PorcentajeIVA { get; set; }
    }
}
