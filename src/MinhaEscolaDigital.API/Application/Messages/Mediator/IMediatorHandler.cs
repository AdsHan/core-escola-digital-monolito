using FluentValidation.Results;
using MinhaEscolaDigital.API.Application.Messages.Commands;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
        Task<object> EnviarQuery<T>(T query);
    }
}