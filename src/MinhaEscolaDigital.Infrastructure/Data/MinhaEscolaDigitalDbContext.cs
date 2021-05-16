
using Microsoft.EntityFrameworkCore;
using MinhaEscolaDigital.Domain.Entities;
using System.Reflection;

namespace MinhaEscolaDigital.Infrastructure.Persistence
{
    public class MinhaEscolaDigitalDbContext : DbContext
    {
        public MinhaEscolaDigitalDbContext(DbContextOptions<MinhaEscolaDigitalDbContext> options) : base(options)
        {

        }

        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Escola> Turma { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Observacao> Observacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
