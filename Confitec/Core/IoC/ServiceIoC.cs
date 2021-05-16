using Dominio.Contratos.Servicos.Base;
using Microsoft.Extensions.DependencyInjection;
using Servico;
using Servico.Base;

namespace Confitec.Core.IoC
{
    public static class ServiceIoC
    {
        public static IServiceCollection AddServiceIoC(this IServiceCollection services)
        {
            services.AddScoped<InjectorServiceBase>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
