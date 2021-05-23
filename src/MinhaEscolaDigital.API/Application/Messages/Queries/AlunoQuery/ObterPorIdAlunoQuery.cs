using MediatR;
using MinhaEscolaDigital.Domain.Entities;
using System;

namespace MinhaEscolaDigital.API.Application.Messages.Queries.AlunoQuery
{
    public class ObterPorIdAlunoQuery : IRequest<Aluno>
    {
        public ObterPorIdAlunoQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
