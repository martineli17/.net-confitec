using Dominio.Entidades;

namespace Dominio.Contratos.Servicos.Base
{
    public interface IUsuarioService : IAddServiceBase<Usuario>, IUpdateServiceBase<Usuario>, 
                                       IRemoveServiceBase, IQueryServiceBase<Usuario>
    {
    }
}
