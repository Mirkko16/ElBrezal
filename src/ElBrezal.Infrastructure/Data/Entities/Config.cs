using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Config
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string? NombreFantasia { get; set; }

    public long CUIT { get; set; }

    public string? DomicilioComercial { get; set; }

    public string? CondFrenteIVA { get; set; }

    public string? IngresosBrutos { get; set; }

    public DateOnly InicioActividades { get; set; }

    public int PuntoVenta { get; set; }

    public int Concepto { get; set; }

    public decimal ImpIVA { get; set; }

    public string MonId { get; set; } = null!;

    public decimal MonCotiz { get; set; }

    public string AmbienteArca { get; set; } = null!;

    public bool FacturacionNegativa { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool FacturacionElectronica { get; set; }

    public string? RutaCertificadoPfx { get; set; }

    public string ModoImpresion { get; set; } = null!;
}
