using ElBrezal.Application.Models.Comprobantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Comprobantes
{
    public interface ITipoComprobanteService
    {
        Task<List<TipoComprobanteDto>> ObtenerTodosAsync();
    }
}
