using ElBrezal.Application.Models.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Productos
{
    public interface IUnidadService
    {
        Task<List<UnidadDto>> ObtenerTodasAsync();

        Task AgregarAsync(string descripcion);

        Task EliminarAsync(int id);
    }
}
