using MediatR;
using MinhaEscolaDigital.Domain.Entities;
using MinhaEscolaDigital.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Queries.AlunoQuery
{
    public class AlunoQueryHandler :
        IRequestHandler<ObterTodosAlunoQuery, List<Aluno>>,
        IRequestHandler<ObterPorIdAlunoQuery, Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoQueryHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<List<Aluno>> Handle(ObterTodosAlunoQuery request, CancellationToken cancellationToken)
        {
            return await _alunoRepository.ObterTodosAsync();
        }

        public async Task<Aluno> Handle(ObterPorIdAlunoQuery request, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(request.Id);

            if (aluno == null) return null;

            return aluno;
        }
    }

}
