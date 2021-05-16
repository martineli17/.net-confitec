using Crosscuting.Notificacoes;
using System.Collections.Generic;

namespace Crosscuting.Contratos.Notificacoes
{
    public interface INotificador
    {
        void Add(string mensagem, EnumTipoMensagem tipo = EnumTipoMensagem.Alerta);
        void AddRange(IEnumerable<string> mensagens, EnumTipoMensagem tipo = EnumTipoMensagem.Alerta);
        void Limpar();
        bool ContemMensagens();
        bool IsValido();
        IEnumerable<MensagemNotificacao> Mensagens();
    }
}
