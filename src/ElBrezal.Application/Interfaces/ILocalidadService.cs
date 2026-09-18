using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface ILocalidadService
    {
        Task<List<LocalidadDto>> ObtenerTodasAsync();

        Task AgregarAsync(string nombre, string codigoPostal, int provinciaId);

        Task ModificarAsync( int id, string nombre, string codigoPostal, int provinciaId);

        Task EliminarAsync(int id);

    }
}
