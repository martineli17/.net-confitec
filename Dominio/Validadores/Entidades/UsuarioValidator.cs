using Dominio.Entidades;
using FluentValidation;
using System;

namespace Dominio.Validadores.Entidades
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Nome"))
                                .MaximumLength(100).WithMessage(MensagemValidator.NaoMaior("Nome"));
            RuleFor(x => x.Sobrenome).NotEmpty().WithMessage(MensagemValidator.NaoNuloOuVazio("Sobrenome"))
                               .MaximumLength(100).WithMessage(MensagemValidator.NaoMaior("Sobrenome"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(MensagemValidator.EmailInvalido("Email"))
                               .MaximumLength(60).WithMessage(MensagemValidator.NaoMaior("Email"));
            RuleFor(x => x.DataNascimento).LessThan(DateTime.Now).WithMessage(MensagemValidator.NaoMaiorOuIgual("Data de Nascimento"));
            RuleFor(x => x.Escolaridade).IsInEnum().WithMessage(MensagemValidator.IsEnum("Escolaridade"));
        }
    }
}
