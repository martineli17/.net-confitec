using Crosscuting.Contratos.Notificacoes;
using Dominio.Contratos.Repositorios.Base;

namespace Servico.Base
{
    public class InjectorServiceBase
    {
        public readonly INotificador Notificador;
        public readonly IUnitOfWork UnitOfWork;
        public InjectorServiceBase(INotificador notificador, IUnitOfWork unitOfWork)
        {
            Notificador = notificador;
            UnitOfWork = unitOfWork;
        }
    }
}
