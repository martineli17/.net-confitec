using Dominio.Contratos.Repositorios.Base;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositorio.Repositorios.Base
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : EntidadeBase
    {
        protected readonly InjectorRepositorioBase Injector;

        public RepositorioBase(InjectorRepositorioBase injector)
        {
            Injector = injector;
        }

        public virtual async Task AddAsync(TEntity entidade)
        {
            await Injector.Context.Set<TEntity>().AddAsync(entidade);
        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            await Task.Yield();
            var query = Injector.Context.Set<TEntity>().AsQueryable();
            if (filter != null)
                query.Where(filter);
            return query;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> query)
        {
            await Task.Yield();
            return await Injector.Context.Set<TEntity>().AnyAsync(query);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var query = Injector.Context.Set<TEntity>().AsQueryable();
            var entidade = await query.FirstOrDefaultAsync(x => x.Id == id);
            if (entidade != null)
                Injector.Context.Entry(entidade).State = EntityState.Detached;
            return entidade;
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var entidade = await GetByIdAsync(id);
            if (entidade == null)
            {
                Injector.Notificador.Add("Registro não encontrado.");
                return;
            }
            Injector.Context.Set<TEntity>().Remove(entidade);
        }

        public virtual async Task UpdateAsync(TEntity entidade)
        {
            await Task.Yield();
            Injector.Context.Set<TEntity>().Update(entidade);
        }

        public virtual async Task UpdatePropsAsync(TEntity entidade, params string[] propriedades)
        {
            if (propriedades is null || !propriedades.Any())
            {
                await UpdateAsync(entidade);
                return;
            }
            var entityEntry = Injector.Context.Entry(entidade);
            foreach (var propriedade in propriedades) entityEntry.Property(propriedade).IsModified = true;
        }

        public void Dispose()
        {
            Injector.Context.Dispose();
        }
    }
}
