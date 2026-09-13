using ElBrezal.Application.Models;

namespace ElBrezal.Application.Interfaces
{
    public interface ISituacionImpositivaService
    {
        Task<List<SituacionImpositivaDto>> ObtenerTodasAsync();
    }
}
