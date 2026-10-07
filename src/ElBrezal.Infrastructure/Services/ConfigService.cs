using ElBrezal.Application.Interfaces.Configuraciones;
using ElBrezal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Infrastructure.Services
{
    public class ConfigService : IConfigService
    {
        private readonly ElBrezalDbContext _context;

        public ConfigService(ElBrezalDbContext context)
        {
            _context = context;
        }

        public async Task<string?> ObtenerValorAsync(string clave)
        {
            return await _context.Config
                .AsNoTracking()
                .Where(x => x.Clave == clave)
                .Select(x => x.Valor)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ObtenerBooleanoAsync(string clave)
        {
            var valor = await ObtenerValorAsync(clave);

            return bool.TryParse(valor, out var resultado)
                && resultado;
        }
    }
}
