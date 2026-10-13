using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Models.Config
{
    public class ConfigDto
    {
        public int Id { get; set; }

        // DATOS DEL NEGOCIO
        public string RazonSocial { get; set; } = string.Empty;
        public string? NombreFantasia { get; set; }
        public long CUIT { get; set; }
        public string? DomicilioComercial { get; set; }
        public string? CondFrenteIVA { get; set; }
        public string? IngresosBrutos { get; set; }
        public DateOnly InicioActividades { get; set; }

        // FACTURACION ELECTRONICA
        public int PuntoVenta { get; set; }
        public int Concepto { get; set; }
        public decimal ImpIVA { get; set; }
        public string MonId { get; set; } = "PES";
        public decimal MonCotiz { get; set; }
        public string AmbienteArca { get; set; } = "HOMOLOGACION";
        public bool FacturacionElectronica { get; set; }
        public string? RutaCertificadoPfx { get; set; }

        // CONFIGURACION COMERCIAL
        public bool FacturacionNegativa { get; set; }

        // AUDITORIA
        public DateTime UpdatedAt { get; set; }

        // SISTEMA E IMPRESION
        public string ModoImpresion { get; set; } = "PREGUNTAR";
    }
}
