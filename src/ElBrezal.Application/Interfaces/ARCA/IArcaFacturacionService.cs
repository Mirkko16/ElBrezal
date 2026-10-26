using ElBrezal.Application.Models.ARCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.ARCA
{
    public interface IArcaFacturacionService
    {
        Task<ArcaPuntosVentaResultadoDto> ObtenerPuntosVentaAsync(ArcaAuthDto auth, long cuitEmisor, string ambiente, CancellationToken cancellationToken = default);

        Task<string> ConsultarEstadoServicioAsync(CancellationToken cancellationToken = default);

        Task<ArcaTiposComprobanteResultadoDto> ObtenerTiposComprobanteAsync(ArcaAuthDto auth, long cuitEmisor, string ambiente, CancellationToken cancellationToken = default);

        Task<ArcaUltimoComprobanteDto> ObtenerUltimoComprobanteAutorizadoAsync( ArcaAuthDto auth, long cuitEmisor, string ambiente, int puntoVenta,
            int tipoComprobante, CancellationToken cancellationToken = default);


        Task<ArcaResultadoCaeDto> SolicitarCaeAsync(ArcaAuthDto auth, long cuitEmisor, string ambiente, ArcaSolicitudCaeDto solicitud,
        CancellationToken cancellationToken = default);

        Task<ArcaResultadoCaeDto?> ConsultarComprobanteAsync(ArcaAuthDto auth, long cuitEmisor, string ambiente, int puntoVenta,
            int tipoComprobante, long numero, CancellationToken cancellationToken = default);
    }
}
