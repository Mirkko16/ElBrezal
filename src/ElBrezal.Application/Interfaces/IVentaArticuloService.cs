using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface IVentaArticuloService
    {
        Task<List<VentaArticuloValorizadaDto>> ObtenerValorizadasAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
}
