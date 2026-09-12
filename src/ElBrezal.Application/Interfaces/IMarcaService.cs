using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface IMarcaService
    {
        Task<List<MarcaDto>> ObtenerTodasAsync();

        Task AgregarAsync(string nombre);

        Task EliminarAsync(int id);
    }
}
