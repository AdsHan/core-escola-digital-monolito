using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaEscolaDigital.Infrastructure.Persistence;

namespace MinhaEscolaDigital.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // API
            services.AddDbContext<MinhaEscolaDigitalDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Commands


            // Events


            // Application


            // Data

        }
    }
}