using FluentValidation.Results;
using System;

namespace MinhaEscolaDigital.API.Application.ApplicationObjects
{
    public class BaseResult
    {
        public ValidationResult ValidationResult { get; set; }
        public Guid id { get; set; }

        public BaseResult()
        {
            ValidationResult = new ValidationResult();
            id = Guid.Empty;
        }

    }
}