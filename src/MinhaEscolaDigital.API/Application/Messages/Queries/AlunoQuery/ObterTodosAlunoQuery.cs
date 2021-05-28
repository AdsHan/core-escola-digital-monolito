
using MediatR;
using MinhaEscolaDigital.API.Application.DTO;
using System.Collections.Generic;

namespace MinhaEscolaDigital.API.Application.Messages.Queries.AlunoQuery
{

    public class ObterTodosAlunoQuery : IRequest<List<AlunoDTO>>
    {
    }

}
