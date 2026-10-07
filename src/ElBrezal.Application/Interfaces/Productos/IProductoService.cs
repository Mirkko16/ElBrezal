using ElBrezal.Application.Models.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Productos
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> ObtenerTodosAsync();

        Task AgregarAsync(ProductoDto producto);

        Task ModificarAsync(ProductoDto producto);
        Task<List<ProductoDto>> ObtenerConStockMinimoAsync();
        Task<ProductoDto?> ObtenerPorIdAsync(int id);

        Task EliminarAsync(int id);
    }
}
