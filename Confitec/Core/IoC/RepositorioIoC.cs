using Dominio.Contratos.Repositorios;
using Dominio.Contratos.Repositorios.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Contexto;
using Repositorio.Repositorios;
using Repositorio.Repositorios.Base;

namespace Confitec.Core.IoC
{
    public static class RepositorioIoC
    {
        public static IServiceCollection AddRepositorioIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ConfitecContext>(x => new ConfitecContext(configuration.GetConnectionString("BancoConfitec")));
            services.AddScoped<InjectorRepositorioBase>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            return services;
        }
    }
}
