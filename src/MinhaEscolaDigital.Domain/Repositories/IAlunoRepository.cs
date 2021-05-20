using MinhaEscolaDigital.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.Domain.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterPorCpf(string cpf);
        Task<Aluno> ObterPorRG(string cpf);

        // Aluno
        void AdicionarEndereco(Endereco endereco);
        Task<Endereco> ObterEnderecoPorId(Guid id);

    }
}
