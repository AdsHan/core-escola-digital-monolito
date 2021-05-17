using MinhaEscolaDigital.Domain.DomainObjects;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Responsavel : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public Responsavel()
        {
        }

        public Responsavel(string nome, DateTime dataNascimento, string rg, string cpf, string telefone, string celular, string email, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Rg = new Rg(rg);
            Cpf = new Cpf(cpf);
            Email = new Email(email);
            Telefone = new Telefone(telefone);
            Celular = new Telefone(celular);
            Observacao = new Observacao(observacao);
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Rg Rg { get; private set; }
        public Cpf Cpf { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Telefone Celular { get; private set; }
       
        public Guid ObservacaoId { get; private set; }

        // EF Relação
        public Observacao Observacao { get; private set; }
        public List<AlunoResponsavel> AlunosResponsaveis { get; set; }

    }
}
