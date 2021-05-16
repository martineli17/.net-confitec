using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; set; }
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public abstract (bool IsValido, IReadOnlyList<string> Erros) Validar();

        protected (bool IsValido, IReadOnlyList<string> Erros) Validar<TObject>(AbstractValidator<TObject> validator, TObject dados) where TObject : EntidadeBase
        {
            if (dados is null)
                return (false, new List<string> { "Dados inválidos" });
            var erros = new List<string>();
            var validacao = validator.Validate(dados);
            if (!validacao.IsValid)
                erros.AddRange(validacao.Errors.Select(x => x.ErrorMessage).ToList());
            return (validacao.IsValid, erros);
        }
    }
}
