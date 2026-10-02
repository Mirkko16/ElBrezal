using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface IConfigService
    {
        Task<string?> ObtenerValorAsync(string clave);
        Task<bool> ObtenerBooleanoAsync(string clave);
    }
}
