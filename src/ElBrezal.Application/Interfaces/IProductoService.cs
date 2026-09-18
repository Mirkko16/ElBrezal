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

        Task EliminarAsync(int id);
    }
}
