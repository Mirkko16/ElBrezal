using ElBrezal.Application.Models.Estadisticas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Comprobantes
{
    public interface IVentaArticuloService
    {
        Task<List<VentaArticuloValorizadaDto>> ObtenerValorizadasAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
}
