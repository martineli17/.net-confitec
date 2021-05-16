using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Contratos.Servicos.Base
{
    public interface IAddServiceBase<TEntidade> where TEntidade : EntidadeBase
    {
        Task<TEntidade> AddAsync(TEntidade entidade);
    }
}
