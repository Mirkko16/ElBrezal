using ElBrezal.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Application.Interfaces
{
    public interface ICondicionVentaService
    {
        Task<List<CondicionVentaDto>> ObtenerTodasAsync();
    }
}
