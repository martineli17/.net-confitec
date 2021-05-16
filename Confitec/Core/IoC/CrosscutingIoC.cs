using Crosscuting.Contratos.Notificacoes;
using Crosscuting.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace Confitec.Core.IoC
{
    public static class CrosscutingIoC
    {
        public static IServiceCollection AddCrosscutingIoC(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
