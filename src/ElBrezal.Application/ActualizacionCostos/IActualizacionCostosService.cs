using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.ActualizacionCostos
{
    public interface IActualizacionCostosService
    {
        Task<List<ActualizacionCostoProductoDto>> BuscarProductosAsync(int? familiaId, int? marcaId, int? proveedorId);

        Task AplicarActualizacionAsync(IEnumerable<int> productosIds, TipoActualizacionCosto tipoActualizacion, decimal valor);
    }
}
