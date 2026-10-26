using ElBrezal.Application.Models.ARCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.ARCA
{
    public interface IComprobanteAutorizacionService
    {
        Task<List<ComprobantePendienteDto>> ObtenerPendientesAsync(CancellationToken cancellationToken = default);

        Task<ArcaResultadoCaeDto>AutorizarAsync(int comprobanteId, CancellationToken cancellationToken = default);

        Task<ArcaResultadoCaeDto?>ConsultarAutorizacionAsync(int comprobanteId, CancellationToken cancellationToken = default);
    }
}
