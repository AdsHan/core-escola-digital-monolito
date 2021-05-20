using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Repositories;
using System;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class ResumoDia : BaseEntity, IAggregateRoot
    {

        // EF Construtor
        public ResumoDia()
        {
        }

        public ResumoDia(DateTime data, string texto)
        {
            DataResumo = data;
            Texto = texto;
        }

        public DateTime DataResumo { get; private set; }
        public string Texto { get; private set; }
        public Guid AlunoId { get; private set; }

        // EF Relação
        public Aluno Aluno { get; private set; }

    }
}
