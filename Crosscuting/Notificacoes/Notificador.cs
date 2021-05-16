using Crosscuting.Contratos.Notificacoes;
using System.Collections.Generic;
using System.Linq;

namespace Crosscuting.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<MensagemNotificacao> _mensagens;

        public Notificador()
        {
            _mensagens = new List<MensagemNotificacao>();
        }
        public void Add(string mensagem, EnumTipoMensagem tipo = EnumTipoMensagem.Alerta)
            => _mensagens.Add(new MensagemNotificacao { Mensagem = mensagem, Tipo = tipo });

        public void AddRange(IEnumerable<string> mensagens, EnumTipoMensagem tipo = EnumTipoMensagem.Alerta)
        {
            foreach (var item in mensagens) Add(item, tipo);
        }

        public bool ContemMensagens() => _mensagens.Any();

        public bool IsValido() => !_mensagens.Any(x => x.Tipo == EnumTipoMensagem.Alerta || x.Tipo == EnumTipoMensagem.Erro);

        public void Limpar() => _mensagens.Clear();

        IEnumerable<MensagemNotificacao> INotificador.Mensagens() => _mensagens;
    }
}
