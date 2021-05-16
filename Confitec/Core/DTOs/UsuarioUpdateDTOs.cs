using Dominio.ValuesType;
using System;

namespace Confitec.Core.DTOs
{
    public class UsuarioUpdateRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnumEscolaridade Escolaridade { get; set; }
    }

    public class UsuarioUpdateResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnumEscolaridade Escolaridade { get; set; }
    }
}
