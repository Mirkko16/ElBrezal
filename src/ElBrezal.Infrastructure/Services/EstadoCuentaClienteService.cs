using ElBrezal.Application.Interfaces.Clientes;
using ElBrezal.Application.Models.Clientes;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Services
{
    public class EstadoCuentaClienteService : IEstadoCuentaClienteService
    {
        private readonly ElBrezalDbContext _context;

        public EstadoCuentaClienteService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstadoCuentaClienteDto>> ObtenerTodosAsync()
        {
            return await _context.EstadosCuentaCliente
                .AsNoTracking()
                .OrderBy(x => x.Nombre)
                .Select(x => new EstadoCuentaClienteDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                })
                .ToListAsync();
        }

    }
}
