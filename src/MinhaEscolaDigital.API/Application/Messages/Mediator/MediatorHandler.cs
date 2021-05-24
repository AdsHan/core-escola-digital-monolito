using FluentValidation.Results;
using MediatR;
using MinhaEscolaDigital.API.Application.Messages.Commands;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task<object> EnviarQuery<T>(T query)
        {
            return await _mediator.Send(query);
        }
    }
}