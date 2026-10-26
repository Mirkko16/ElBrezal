using ElBrezal.Application.Models.ARCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.ARCA
{
    public interface IArcaAuthService
    {
        Task<ArcaAuthDto> AutenticarAsync(
            string rutaCertificadoPfx,
            string password,
            string ambiente = "HOMOLOGACION",
            CancellationToken cancellationToken = default);
    }
}
