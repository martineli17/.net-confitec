using Dominio.Validadores.Entidades;
using Dominio.ValuesType;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnumEscolaridade Escolaridade { get; set; }
        public Usuario()
        {

        }
        public override (bool IsValido, IReadOnlyList<string> Erros) Validar() =>  base.Validar(new UsuarioValidator(), this);
    }
}
