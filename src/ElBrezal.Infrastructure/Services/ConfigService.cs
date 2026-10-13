using ElBrezal.Application.Interfaces.Configuraciones;
using ElBrezal.Application.Models.Config;
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

        public async Task<ConfigDto?> ObtenerAsync()
        {
            return await _context.Config
                .AsNoTracking()
                .Select(x => new ConfigDto
                {
                    Id = x.Id,
                    RazonSocial = x.RazonSocial,
                    NombreFantasia = x.NombreFantasia,
                    CUIT = x.CUIT,
                    DomicilioComercial = x.DomicilioComercial,
                    CondFrenteIVA = x.CondFrenteIVA,
                    IngresosBrutos = x.IngresosBrutos,
                    InicioActividades = x.InicioActividades,
                    PuntoVenta = x.PuntoVenta,
                    Concepto = x.Concepto,
                    ImpIVA = x.ImpIVA,
                    MonId = x.MonId,
                    MonCotiz = x.MonCotiz,
                    AmbienteArca = x.AmbienteArca,
                    FacturacionNegativa = x.FacturacionNegativa,
                    FacturacionElectronica = x.FacturacionElectronica,
                    RutaCertificadoPfx = x.RutaCertificadoPfx,
                    ModoImpresion = x.ModoImpresion,
                    UpdatedAt = x.UpdatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task GuardarAsync(ConfigDto config)
        {
            ArgumentNullException.ThrowIfNull(config);

            var entidad = await _context.Config
                .FirstOrDefaultAsync();

            if (entidad == null)
            {
                entidad = new ElBrezal.Infrastructure.Data.Entities.Config();
                _context.Config.Add(entidad);
            }

            // DATOS DEL NEGOCIO
            entidad.RazonSocial = config.RazonSocial;
            entidad.NombreFantasia = config.NombreFantasia;
            entidad.CUIT = config.CUIT;
            entidad.DomicilioComercial = config.DomicilioComercial;
            entidad.CondFrenteIVA = config.CondFrenteIVA;
            entidad.IngresosBrutos = config.IngresosBrutos;
            entidad.InicioActividades = config.InicioActividades;

            // FACTURACION
            entidad.PuntoVenta = config.PuntoVenta;
            entidad.Concepto = config.Concepto;
            entidad.ImpIVA = config.ImpIVA;
            entidad.MonId = config.MonId;
            entidad.MonCotiz = config.MonCotiz;
            entidad.AmbienteArca = config.AmbienteArca;
            entidad.FacturacionNegativa = config.FacturacionNegativa;
            entidad.FacturacionElectronica = config.FacturacionElectronica;
            entidad.RutaCertificadoPfx = config.RutaCertificadoPfx;

            // SISTEMA
            entidad.ModoImpresion = config.ModoImpresion;

            // AUDITORIA
            entidad.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> PermiteFacturacionNegativaAsync()
        {
            return await _context.Config
                .AsNoTracking()
                .Select(x => x.FacturacionNegativa)
                .FirstOrDefaultAsync();
        }

        // COMPATIBILIDAD TEMPORAL

        public async Task<string?> ObtenerValorAsync(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
                return null;

            var config = await ObtenerAsync();

            if (config == null)
                return null;

            return clave.ToUpperInvariant() switch
            {
                "FACTNEGATIVA" =>
                    config.FacturacionNegativa.ToString(),

                _ => null
            };
        }

        public async Task<bool> ObtenerBooleanoAsync(string clave)
        {
            if (string.Equals(
                clave,
                "FACTNEGATIVA",
                StringComparison.OrdinalIgnoreCase))
            {
                return await PermiteFacturacionNegativaAsync();
            }

            return false;
        }
    }
}