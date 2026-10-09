using System;
using System.Collections.Generic;

namespace ElBrezal.Infrastructure.Data.Entities;

public partial class Comprobantes
{
    public int Id { get; set; }

    public int TipoComprobanteId { get; set; }

    public int PuntoVenta { get; set; }

    public int Numero { get; set; }

    public DateTime Fecha { get; set; }

    public int ClienteId { get; set; }

    public int VendedorId { get; set; }

    public int CondicionVentaId { get; set; }

    public int SituacionImpositivaId { get; set; }

    public decimal PorcentajeVariacion { get; set; }

    public decimal Subtotal { get; set; }

    public decimal MontoVariacion { get; set; }

    public decimal Total { get; set; }

    public string? Observacion { get; set; }

    public bool Anulado { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ComprobanteOrigenId { get; set; }

    public virtual Clientes Cliente { get; set; } = null!;

    public virtual Comprobantes? ComprobanteOrigen { get; set; }

    public virtual ICollection<ComprobantesDetalle> ComprobantesDetalle { get; set; } = new List<ComprobantesDetalle>();

    public virtual CondicionesVenta CondicionVenta { get; set; } = null!;

    public virtual ICollection<Comprobantes> InverseComprobanteOrigen { get; set; } = new List<Comprobantes>();

    public virtual SituacionesImpositivas SituacionImpositiva { get; set; } = null!;

    public virtual TiposComprobante TipoComprobante { get; set; } = null!;

    public virtual Vendedores Vendedor { get; set; } = null!;
}
