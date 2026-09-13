using ElBrezal.Application.Models;

namespace ElBrezal.Application.Interfaces
{
    public interface IEstadoCuentaClienteService
    {
        Task<List<EstadoCuentaClienteDto>> ObtenerTodosAsync();
    }
}
