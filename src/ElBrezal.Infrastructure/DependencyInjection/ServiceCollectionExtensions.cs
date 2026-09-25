using ElBrezal.Application.ActualizacionCostos;
using ElBrezal.Application.Interfaces;
using ElBrezal.Application.Interfaces.ElBrezal.Application.Interfaces;
using ElBrezal.Infrastructure.Data;
using ElBrezal.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElBrezal.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ElBrezalDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<IMarcaService, MarcaService>();            
            services.AddTransient<IFamiliaService, FamiliaService>();
            services.AddTransient<IUnidadService, UnidadService>();
            services.AddTransient<ILocalidadService, LocalidadService>();
            services.AddTransient<IProvinciaService, ProvinciaService>();
            services.AddTransient<IEstadoCuentaClienteService, EstadoCuentaClienteService>();
            services.AddTransient<ISituacionImpositivaService, SituacionImpositivaService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IVendedorService, VendedorService>();
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IAlicuotaIVAService, AlicuotaIVAService>();
            services.AddTransient<IActualizacionCostosService, ActualizacionCostosService>();
            services.AddTransient<ICondicionVentaService, CondicionVentaService>();
            services.AddTransient<ITipoComprobanteService, TipoComprobanteService>();
            services.AddTransient<INumeracionComprobanteService, NumeracionComprobanteService>();


            return services;
        }
    }
}
