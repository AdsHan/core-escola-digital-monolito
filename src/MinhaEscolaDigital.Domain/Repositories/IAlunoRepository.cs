using MinhaEscolaDigital.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.Domain.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterPorCpfAsync(string cpf);
        Task<Aluno> ObterPorRgAsync(string rg);
        Task<Endereco> ObterEnderecoPorIdAsync(Guid id);
        Task<Responsavel> ObterResponsavelPorIdAsync(Guid id);
    }
}
