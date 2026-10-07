using ElBrezal.Application.Models.Proveedores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Proveedores
{
    public interface IProveedorService
    {
        Task<List<ProveedorDto>> ObtenerTodosAsync();

        Task AgregarAsync(ProveedorDto proveedor);

        Task ModificarAsync(ProveedorDto proveedor);

        Task EliminarAsync(int id);
    }
}
