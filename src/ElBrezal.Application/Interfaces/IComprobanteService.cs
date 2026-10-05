using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface IComprobanteService
    {
        Task<ComprobanteCreadoDto> CrearAsync(CrearComprobanteDto comprobante);

        Task<ComprobanteDto?> ObtenerPresupuestoAsync(int puntoVenta, int numero);
    }
}
