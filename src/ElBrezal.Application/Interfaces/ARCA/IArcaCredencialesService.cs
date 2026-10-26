using ElBrezal.Application.Models.ARCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.ARCA
{
    public interface IArcaCredencialesService
    {
        Task<ArcaAuthDto> ObtenerCredencialesValidasAsync(
            long cuitEmisor,
            string ambiente,
            string rutaCertificadoPfx,
            string? password = null,
            CancellationToken cancellationToken = default);
    }
}
