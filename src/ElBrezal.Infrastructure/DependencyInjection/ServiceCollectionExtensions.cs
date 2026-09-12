using ElBrezal.Application.Interfaces;
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

            return services;
        }
    }
}
