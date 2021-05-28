using FluentValidation.Results;
using MinhaEscolaDigital.API.Application.ApplicationObjects;

namespace MinhaEscolaDigital.API.Application.Messages.Commands
{
    public abstract class CommandHandler
    {
        protected BaseResult BaseResult;

        protected CommandHandler()
        {
            BaseResult = new BaseResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            BaseResult.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

    }
}