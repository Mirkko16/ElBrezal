using ElBrezal.Application.Models.Clientes;

namespace ElBrezal.Application.Interfaces.Comprobantes
{
    public interface ISituacionImpositivaService
    {
        Task<List<SituacionImpositivaDto>> ObtenerTodasAsync();
    }
}
