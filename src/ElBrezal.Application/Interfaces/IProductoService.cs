using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
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
