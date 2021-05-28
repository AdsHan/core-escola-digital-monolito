using MediatR;
using MinhaEscolaDigital.API.Application.ApplicationObjects;
using System;

namespace MinhaEscolaDigital.API.Application.Messages.Commands
{
    public abstract class Command : IRequest<BaseResult>
    {
        protected Command()
        {
            BaseResult = new BaseResult();
        }

        public BaseResult BaseResult { get; set; }

        public virtual bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}