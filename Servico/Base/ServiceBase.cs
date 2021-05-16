using Dominio.Contratos.Repositorios.Base;
using Dominio.Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servico.Base
{
    public class ServiceBase<TEntidade> where TEntidade : EntidadeBase
    {
        protected readonly IRepositorioBase<TEntidade> Repositorio;
        protected readonly InjectorServiceBase Injector;

        public ServiceBase(IRepositorioBase<TEntidade> repositorio, InjectorServiceBase injector)
        {
            Repositorio = repositorio;
            Injector = injector;
        }

        public virtual async Task<IQueryable<TEntidade>> GetAsync(Expression<Func<TEntidade, bool>> query = null)
            => await Repositorio.GetAsync(query);
        public virtual async Task<TEntidade> GetByIdAsync(Guid id)
        {
            var entidade = await Repositorio.GetByIdAsync(id);
            if (entidade is null)
                Injector.Notificador.Add("Registro solicitado não encontrado.");
            return entidade;
        }
        protected async Task<TEntidade> AddAsync(TEntidade entidade)
        {
            await Repositorio.AddAsync(entidade);
            return entidade;
        }
        protected async Task<bool> RemoveAsync(Guid id)
        {
            if (!await ValidarExistenciaEntidadeAsync(id))
                return false;
            await Repositorio.RemoveAsync(id);
            return true;
        }
        protected async Task<TEntidade> UpdateAsync(TEntidade entidade, params string[] props)
        {
            if (!await ValidarExistenciaEntidadeAsync(entidade.Id))
                return null;
            await Repositorio.UpdatePropsAsync(entidade, props);
            return entidade;
        }
        protected async Task<bool> ValidarExistenciaEntidadeAsync(Guid id)
        {
            if (!await Repositorio.ExistsAsync(x => x.Id == id))
            {
                Injector.Notificador.Add(MensagemValidator.RegistroNaoEncontrado("Registro"));
                return false;
            }
            return true;
        }
        protected bool ValidarEntidade(TEntidade entidade)
        {
            var validacaoEntidade = entidade.Validar();
            if (!validacaoEntidade.IsValido)
                Injector.Notificador.AddRange(validacaoEntidade.Erros);
            return validacaoEntidade.IsValido;
        }
        protected async Task<bool> CommitAsync() => await Injector.UnitOfWork.CommitAsync();
    }
}
