using ElBrezal.Application.Models.Localizacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces.Localizacion
{
    public interface IProvinciaService
    {
        Task<List<ProvinciaDto>> ObtenerTodasAsync();
    }
}
