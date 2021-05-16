using Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Servicos.Base
{
    public interface IQueryServiceBase<TEntidade> where TEntidade : EntidadeBase
    {
        Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}
