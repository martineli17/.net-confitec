using Dominio.Contratos.Repositorios;
using Dominio.Contratos.Repositorios.Base;
using Dominio.Contratos.Servicos.Base;
using Dominio.Entidades;
using Servico.Base;
using System;
using System.Threading.Tasks;

namespace Servico
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepositorio repositorio, InjectorServiceBase injector) : base(repositorio, injector)
        {
        }

        public new async Task<Usuario> AddAsync(Usuario entidade)
        {
            if (!base.ValidarEntidade(entidade)) return null;

            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }

        public new async Task<bool> RemoveAsync(Guid id)
        {
            if (!await base.ValidarExistenciaEntidadeAsync(id))
                return false;
            await base.RemoveAsync(id);
            return await base.CommitAsync();
        }

        public new async Task<Usuario> UpdateAsync(Usuario entidade, params string[] props)
        {
            if (!base.ValidarEntidade(entidade)) return null;
            if(await base.UpdateAsync(entidade, props) != null)
                await base.CommitAsync();
            return entidade;
        }
    }
}
