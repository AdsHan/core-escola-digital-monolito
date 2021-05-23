
using MediatR;
using MinhaEscolaDigital.Domain.Entities;
using System.Collections.Generic;

namespace MinhaEscolaDigital.API.Application.Messages.Queries.AlunoQuery
{

    public class ObterTodosAlunoQuery : IRequest<List<Aluno>>
    {
    }

}
