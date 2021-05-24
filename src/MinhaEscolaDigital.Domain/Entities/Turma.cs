using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Turma : BaseEntity, IAggregateRoot
    {

        // EF Construtor
        public Turma()
        {
        }

        public Turma(string nome, string observacao, Guid escolaId)
        {
            EscolaId = escolaId;
            Nome = nome;
            Observacao = new Observacao(observacao);
            Alunos = new List<Aluno>();
        }

        public string Nome { get; private set; }
        public List<Aluno> Alunos { get; private set; }

        public Guid EscolaId { get; private set; }
        public Guid ObservacaoId { get; private set; }

        // EF Relação        
        public Observacao Observacao { get; private set; }
        public Escola Escola { get; private set; }

        public void AtribuirAlunos(List<Aluno> alunos)
        {
            Alunos = alunos;
        }
    }
}
