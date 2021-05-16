using Crosscuting.Contratos.Notificacoes;
using Repositorio.Contexto;

namespace Repositorio.Repositorios.Base
{
    public class InjectorRepositorioBase
    {
        public readonly ConfitecContext Context;
        public readonly INotificador Notificador;

        public InjectorRepositorioBase(ConfitecContext context, INotificador notificador)
        {
            Context = context;
            Notificador = notificador;
        }
    }
}
