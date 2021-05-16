using System;
using System.Threading.Tasks;

namespace Dominio.Contratos.Servicos.Base
{
    public interface IRemoveServiceBase
    {
        Task<bool> RemoveAsync(Guid id);
    }
}
