using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface ITipoComprobanteService
    {
        Task<List<TipoComprobanteDto>> ObtenerTodosAsync();
    }
}
