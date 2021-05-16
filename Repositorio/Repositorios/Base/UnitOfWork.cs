using Crosscuting.Contratos.Notificacoes;
using Crosscuting.Notificacoes;
using Dominio.Contratos.Repositorios.Base;
using Repositorio.Contexto;
using System;
using System.Threading.Tasks;

namespace Repositorio.Repositorios.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConfitecContext _context;
        private readonly INotificador _notificador;
        public UnitOfWork(ConfitecContext context, INotificador notificador)
        {
            _context = context;
            _notificador = notificador;
        }
        public async Task<bool> CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _notificador.Add("Ocorreu um erro ao processar a operação.", EnumTipoMensagem.Alerta);
                return false;
            }
        }
    }
}
