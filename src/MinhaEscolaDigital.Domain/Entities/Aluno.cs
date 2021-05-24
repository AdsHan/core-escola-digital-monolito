using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Aluno : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public Aluno()
        {
        }

        public Aluno(string nome, DateTime dataNascimento, string rg, string cpf, string observacao, Guid turmaId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            TurmaId = turmaId;
            Rg = new Rg(rg);
            Cpf = new Cpf(cpf);
            Observacao = new Observacao(observacao);
            Endereco = new Endereco();
            AlunosResponsaveis = new List<AlunoResponsavel>();
            Resumos = new List<ResumoDia>();
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }

        public Guid TurmaId { get; private set; }
        public Guid EnderecoId { get; private set; }
        public Guid ObservacaoId { get; private set; }

        public List<AlunoResponsavel> AlunosResponsaveis { get; set; }
        public List<ResumoDia> Resumos { get; private set; }

        // EF Relação
        public Observacao Observacao { get; private set; }
        public Endereco Endereco { get; private set; }
        public Turma Turma { get; private set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AtribuirResponsaveis(List<AlunoResponsavel> responsaveis)
        {
            AlunosResponsaveis = responsaveis;
        }

        public void AtribuirResumos(List<ResumoDia> resumos)
        {
            Resumos = resumos;
        }

        public void Atualizar(string nome, DateTime dataNascimento, string rg, string cpf, string observacao, Guid turma)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg.Atualizar(rg);
            Cpf.Atualizar(cpf);
            Observacao.Atualizar(observacao);
            TurmaId = turma;
        }

    }
}
