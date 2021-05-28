using AutoMapper;
using MediatR;
using MinhaEscolaDigital.API.Application.DTO;
using MinhaEscolaDigital.Domain.Entities;
using MinhaEscolaDigital.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Application.Messages.Queries.AlunoQuery
{
    public class AlunoQueryHandler :
        IRequestHandler<ObterTodosAlunoQuery, List<AlunoDTO>>,
        IRequestHandler<ObterPorIdAlunoQuery, Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoQueryHandler(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _alunoRepository = alunoRepository;
        }

        public async Task<List<AlunoDTO>> Handle(ObterTodosAlunoQuery request, CancellationToken cancellationToken)
        {
            var alunos = await _alunoRepository.ObterTodosAsync();

            var alunosDTO = _mapper.Map<List<AlunoDTO>>(alunos);

            return alunosDTO;
        }

        public async Task<Aluno> Handle(ObterPorIdAlunoQuery request, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(request.Id);

            if (aluno == null) return null;

            return aluno;
        }
    }

}
