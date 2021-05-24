using FluentValidation.Results;
using MediatR;
using System;

namespace MinhaEscolaDigital.API.Application.Messages.Commands
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}