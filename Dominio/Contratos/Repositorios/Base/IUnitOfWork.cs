using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios.Base
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
