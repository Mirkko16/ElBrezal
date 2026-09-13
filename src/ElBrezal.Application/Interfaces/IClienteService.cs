using ElBrezal.Application.Models;

namespace ElBrezal.Application.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> ObtenerTodosAsync();

        Task AgregarAsync(ClienteDto cliente);

        Task ModificarAsync(ClienteDto cliente);

        Task EliminarAsync(int id);
    }
}
