using System;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class AlunoResponsavel
    {
        public AlunoResponsavel()
        {
        }

        public AlunoResponsavel(Aluno aluno, Responsavel responsavel)
        {
            Aluno = aluno;
            Responsavel = responsavel;
        }

        public Guid AlunoId { get; private set; }
        public Guid ResponsavelId { get; private set; }

        // EF Relação
        public Aluno Aluno { get; private set; }
        public Responsavel Responsavel { get; private set; }
    }
}
