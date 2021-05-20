using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscolaDigital.Domain.Entities;

namespace MinhaEscolaDigital.Infrastructure.Data.Mapping
{
    public class AlunoResponsavelMapping : IEntityTypeConfiguration<AlunoResponsavel>
    {
        public void Configure(EntityTypeBuilder<AlunoResponsavel> builder)
        {

            builder.HasKey(a => new { a.AlunoId, a.ResponsavelId });

            // N : N => Aluno : Responsavel
            builder
                .HasOne(a => a.Aluno)
                .WithMany(a => a.AlunosResponsaveis)
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(a => a.Responsavel)
                .WithMany(a => a.AlunosResponsaveis)
                .HasForeignKey(a => a.ResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("AlunosResponsaveis");

        }
    }
}
