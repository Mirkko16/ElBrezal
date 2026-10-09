using ElBrezal.Application.Models.Clientes;

namespace ElBrezal.Application.Interfaces.Clientes
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> ObtenerTodosAsync();
        Task<ClienteDto?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(ClienteDto cliente);

        Task ModificarAsync(ClienteDto cliente);

        Task EliminarAsync(int id);
    }
}
