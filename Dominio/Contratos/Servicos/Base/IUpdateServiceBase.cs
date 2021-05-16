using Dominio.Entidades;
using System.Threading.Tasks;

namespace Dominio.Contratos.Servicos.Base
{
    public interface IUpdateServiceBase<TEntidade> where TEntidade : EntidadeBase
    {
        Task<TEntidade> UpdateAsync(TEntidade entidade, params string[] props);
    }
}
