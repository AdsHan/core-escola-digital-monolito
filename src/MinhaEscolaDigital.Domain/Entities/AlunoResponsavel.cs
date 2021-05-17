using MinhaEscolaDigital.Domain.DomainObjects;
using System;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class AlunoResponsavel
    {
        public Guid AlunoId { get; private set; }
        public Guid ResponsavelId { get; private set; }
       
        // EF Relação
        public Aluno Aluno { get; private set; }
        public Responsavel Responsavel { get; private set; }                
    }
}
