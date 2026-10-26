using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.ARCA
{
    /// <summary>
    /// Representa el resultado de una autorización o consulta
    /// de comprobante electrónico ante ARCA.
    /// </summary>
    public class ArcaResultadoCaeDto
    {
        public int PuntoVenta { get; set; }

        public int TipoComprobante { get; set; }

        public long Numero { get; set; }

        /// <summary>
        /// A = Aprobado, R = Rechazado.
        /// </summary>
        public string Resultado { get; set; } = "";

        public string? CAE { get; set; }

        public DateOnly? CAEVencimiento { get; set; }

        /// <summary>
        /// Fecha del comprobante informada por ARCA.
        /// </summary>
        public DateOnly? FechaComprobante { get; set; }

        /// <summary>
        /// Tipo de documento del receptor informado por ARCA.
        /// </summary>
        public int? TipoDocumentoReceptor { get; set; }

        /// <summary>
        /// Número de documento del receptor informado por ARCA.
        /// </summary>
        public long? NumeroDocumentoReceptor { get; set; }

        /// <summary>
        /// Importe total informado por ARCA.
        /// </summary>
        public decimal? ImporteTotal { get; set; }

        public List<string> Errores { get; set; } = new();

        public List<string> Observaciones { get; set; } = new();

        public bool Aprobado =>  Resultado == "A" && !string.IsNullOrWhiteSpace(CAE);

        public string? TipoEmision { get; set; }
    }
}
