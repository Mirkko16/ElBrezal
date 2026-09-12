using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface IFamiliaService
    {
        Task<List<FamiliaDto>> ObtenerTodasAsync();

        Task AgregarAsync(string nombre);

        Task EliminarAsync(int id);
    }
}
