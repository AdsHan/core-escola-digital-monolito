using MinhaEscolaDigital.Domain.DomainObjects;
using System;

namespace MinhaEscolaDigital.Domain.Entities
{
    public class Aluno : BaseEntity, IAggregateRoot
    {

        public Aluno(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Cpf Cpf { get; private set; }
        public Guid EnderecoId { get; private set; }

        // EF Relação
        public Endereco Endereco { get; private set; }

    }
}
