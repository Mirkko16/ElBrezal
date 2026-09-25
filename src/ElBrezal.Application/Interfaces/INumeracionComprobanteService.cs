using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    namespace ElBrezal.Application.Interfaces
    {
        public interface INumeracionComprobanteService
        {
            Task<List<NumeracionComprobanteDto>> ObtenerTodosAsync();

            Task<NumeracionComprobanteDto?> ObtenerPorTipoYPuntoVentaAsync(
                int tipoComprobanteId,
                int puntoVenta);
        }
    }
}
