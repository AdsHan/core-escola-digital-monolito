using MinhaEscolaDigital.Domain.DomainObjects;
using System;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Aluno : BaseEntity, IAggregateRoot
    {
        // EF Construtor
        public Aluno()
        {
        }

        public Aluno(string nome, DateTime dataNascimento, string cpf, string observacao)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = new Cpf(cpf);
            Observacao = new Observacao(observacao);
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Cpf Cpf { get; private set; }
        public Guid EnderecoId { get; private set; }
        public Guid ObservacaoId { get; private set; }

        // EF Relação
        public Endereco Endereco { get; private set; }
        public Observacao Observacao { get; private set; }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
