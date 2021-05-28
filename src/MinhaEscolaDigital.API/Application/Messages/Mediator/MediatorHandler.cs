﻿using MediatR;
using MinhaEscolaDigital.API.Application.ApplicationObjects;
using MinhaEscolaDigital.API.Application.Messages.Commands;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Mediator
{
    //OBSERVAÇÃO: Existe muita discussão referente ao CQRS retornar valores ou não!
    //            Entendo que no caso deste exemplo não estamos implementando uma arquitetura assíncrona 
    //            baseada em filas, mas sim utilizando "tarefas" assíncronas pode irão fornecer
    //            o resultado de conclusão para o comando async.

    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResult> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task<object> EnviarQuery<T>(T query)
        {
            return await _mediator.Send(query);
        }
    }
}