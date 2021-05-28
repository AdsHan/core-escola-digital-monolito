using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Escola : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public Escola()
        {
        }

        public Escola(string razaoSocial, string nomeFantasia, string cnpj, string email, string telefone, string celular, string observacao)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = new Cnpj(cnpj);
            Email = new Email(email);
            Telefone = new Telefone(telefone);
            Celular = new Telefone(celular);
            Observacao = new Observacao(observacao);
            Endereco = new Endereco();
            Turmas = new List<Turma>();
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public Telefone Celular { get; private set; }
        public List<Turma> Turmas { get; private set; }

        public Guid? ObservacaoId { get; private set; }
        public Guid? EnderecoId { get; private set; }

        // EF Relação
        public Observacao Observacao { get; private set; }
        public Endereco Endereco { get; private set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AtribuirTurmas(List<Turma> turmas)
        {
            Turmas = turmas;
        }
    }
}
