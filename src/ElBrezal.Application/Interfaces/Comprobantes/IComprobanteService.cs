using ElBrezal.Application.Models.Comprobantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Comprobantes
{
    public interface IComprobanteService
    {
        Task<ComprobanteCreadoDto> CrearAsync(CrearComprobanteDto comprobante);

        Task<ComprobanteDto?> ObtenerPresupuestoAsync(int puntoVenta, int numero);

        Task<ComprobanteDto?> ObtenerPorIdAsync(int id);

        Task<List<ComprobanteListadoDto>> ObtenerListadoAsync(int? tipoComprobanteId,DateTime fechaDesde, DateTime fechaHasta,int? clienteId = null);

        Task<List<BuscarComprobanteDto>> BuscarAsync(string abreviaturaTipo, int? puntoVenta = null, int? numero = null);
    }
}
