using Dominio.Contratos.Repositorios;
using Dominio.Entidades;
using Repositorio.Repositorios.Base;

namespace Repositorio.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(InjectorRepositorioBase injector) : base(injector)
        {
        }
    }
}
