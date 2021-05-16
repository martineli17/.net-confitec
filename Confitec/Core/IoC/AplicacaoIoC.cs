using Confitec.Controllers.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Core.IoC
{
    public static class AplicacaoIoC
    {
        public static IServiceCollection AddAplicacaoIoC(this IServiceCollection services)
        {
            services.AddScoped<ControllerInjectorBase>();
            return services;
        }
    }
}
