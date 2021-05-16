using Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Contratos.Repositorios.Base
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        Task AddAsync(TEntidade entidade);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(TEntidade entidade);
        Task UpdatePropsAsync(TEntidade entidade, params string[] propriedades);
        Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null);
        Task<bool> ExistsAsync(Expression<Func<TEntidade, bool>> query);
        Task<TEntidade> GetByIdAsync(Guid id);
    }
}
