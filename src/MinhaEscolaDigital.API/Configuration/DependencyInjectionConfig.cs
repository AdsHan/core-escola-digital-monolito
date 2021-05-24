using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinhaEscolaDigital.API.Application.Messages.Commands.AlunoCommand;
using MinhaEscolaDigital.API.Application.Messages.Mediator;
using MinhaEscolaDigital.Domain.Repositories;
using MinhaEscolaDigital.Infrastructure.Data.Repositories;
using MinhaEscolaDigital.Infrastructure.Persistence;

namespace MinhaEscolaDigital.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MinhaEscolaDigitalDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAlunoRepository, AlunoRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // services.AddScoped<IRequestHandler<AdicionarAlunoCommand, ValidationResult>, AlunoCommandHandler>();
            // services.AddScoped<IRequestHandler<AlterarEnderecoAlunoCommand, ValidationResult>, AlunoCommandHandler>();
            services.AddMediatR(typeof(AdicionarAlunoCommand));



        }
    }
}