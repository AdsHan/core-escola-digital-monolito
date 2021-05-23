using FluentValidation.Results;
using MediatR;
using System;

namespace MinhaEscolaDigital.API.Application.Messages
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