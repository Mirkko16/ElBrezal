using ElBrezal.Application.Models.Vendedores;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Vendedores
{
    public interface IVendedorService
    {
        Task<List<VendedorDto>> ObtenerTodosAsync();

        Task<VendedorDto?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(VendedorDto vendedor);

        Task ModificarAsync(VendedorDto vendedor);

        Task EliminarAsync(int id);
    }
}
