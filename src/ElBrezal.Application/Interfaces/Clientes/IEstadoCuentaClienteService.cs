using ElBrezal.Application.Models.Clientes;

namespace ElBrezal.Application.Interfaces.Clientes
{
    public interface IEstadoCuentaClienteService
    {
        Task<List<EstadoCuentaClienteDto>> ObtenerTodosAsync();
    }
}
