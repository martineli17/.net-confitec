using AutoMapper;
using Crosscuting.Contratos.Notificacoes;

namespace Confitec.Controllers.Base
{
    public class ControllerInjectorBase
    {
        public readonly INotificador Notificador;
        public readonly IMapper Mapper;

        public ControllerInjectorBase(INotificador notificador, IMapper mapper)
        {
            Notificador = notificador;
            Mapper = mapper;
        }
    }
}
