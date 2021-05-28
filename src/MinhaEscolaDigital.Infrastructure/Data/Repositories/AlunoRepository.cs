using Microsoft.EntityFrameworkCore;
using MinhaEscolaDigital.Domain.Entities;
using MinhaEscolaDigital.Domain.Enums;
using MinhaEscolaDigital.Domain.Repositories;
using MinhaEscolaDigital.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _dbContext.Enderecos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Responsavel> ObterResponsavelPorIdAsync(Guid id)
        {
            return await _dbContext.Responsaveis
                .Include(a => a.Observacao)
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Aluno> ObterPorCpfAsync(string cpf)
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<Aluno> ObterPorIdAsync(Guid id)
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .Include(x => x.AlunosResponsaveis).ThenInclude(i => i.Responsavel)
                .Include(a => a.Observacao)
                .Include(a => a.Endereco)
                .Include(a => a.Resumos)
                .Include(a => a.Turma)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluno> ObterPorRgAsync(string rg)
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Rg.Numero == rg);
        }

        public async Task<List<Aluno>> ObterTodosAsync()
        {
            return await _dbContext.Alunos
                .Where(a => a.Status == EntityStatusEnum.Ativa)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Alterar(Aluno aluno)
        {
            // Reforço que as entidades foram alteradas
            _dbContext.Entry(aluno).State = EntityState.Modified;
            _dbContext.Entry(aluno.Endereco).State = EntityState.Modified;
            _dbContext.Entry(aluno.Observacao).State = EntityState.Modified;
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
