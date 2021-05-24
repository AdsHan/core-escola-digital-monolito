using Microsoft.EntityFrameworkCore;
using MinhaEscolaDigital.Domain.Entities;
using MinhaEscolaDigital.Domain.Repositories;
using MinhaEscolaDigital.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.Infrastructure.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly MinhaEscolaDigitalDbContext _dbContext;
        public AlunoRepository(MinhaEscolaDigitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Endereco> ObterEnderecoPorIdAsync(Guid id)
        {
            return await _dbContext.Enderecos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Aluno> ObterPorCpfAsync(string cpf)
        {
            return await _dbContext.Alunos.AsNoTracking().FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<Aluno> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Alunos
                .Include(a => a.Resumos)
                .Include(a => a.Turma)
                .Include(a => a.Observacao)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluno> ObterPorRgAsync(string rg)
        {
            return await _dbContext.Alunos.AsNoTracking().FirstOrDefaultAsync(c => c.Rg.Numero == rg);
        }

        public async Task<List<Aluno>> ObterTodosAsync()
        {
            return await _dbContext.Alunos.AsNoTracking().ToListAsync();
        }

        public void Alterar(Aluno aluno)
        {
            // Reforço que ela foi alterada
            _dbContext.Entry(aluno).State = EntityState.Modified;
            _dbContext.Update(aluno);
        }

        public void Adicionar(Aluno aluno)
        {
            _dbContext.Add(aluno);
        }

        public async Task SalvarAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
