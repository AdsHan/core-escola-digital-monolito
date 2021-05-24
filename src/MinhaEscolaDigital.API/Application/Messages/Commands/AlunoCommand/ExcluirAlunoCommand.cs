using FluentValidation;
using System;

namespace MinhaEscolaDigital.API.Application.Messages.Commands.AlunoCommand
{

    public class ExcluirAlunoCommand : Command
    {
        public Guid AlunoId { get; private set; }
        public override bool Validar()
        {
            ValidationResult = new ExcluirAlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ExcluirAlunoValidation : AbstractValidator<ExcluirAlunoCommand>
        {
            public ExcluirAlunoValidation()
            {
                RuleFor(c => c.AlunoId)
                    .NotEmpty()
                    .WithMessage("O código do aluno não foi informado");
            }
        }
    }
}