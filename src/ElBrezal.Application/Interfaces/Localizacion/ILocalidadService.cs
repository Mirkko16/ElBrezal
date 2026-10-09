using ElBrezal.Application.Models.Localizacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Localizacion
{
    public interface ILocalidadService
    {
        Task<List<LocalidadDto>> ObtenerTodasAsync();

        Task AgregarAsync(string nombre, string codigoPostal, int provinciaId);

        Task ModificarAsync( int id, string nombre, string codigoPostal, int provinciaId);

        Task<LocalidadDto?> ObtenerPorIdAsync(int id);

        Task EliminarAsync(int id);

    }
}
