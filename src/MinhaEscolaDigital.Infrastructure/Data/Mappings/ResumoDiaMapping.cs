using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscolaDigital.Domain.Entities;

namespace MinhaEscolaDigital.Infrastructure.Data.Mapping
{
    public class ResumoDiaMapping : IEntityTypeConfiguration<ResumoDia>
    {
        public void Configure(EntityTypeBuilder<ResumoDia> builder)
        {

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Texto)
                .IsRequired()
                .HasColumnType("varchar(8000)");

            // N : 1 => Resumo Dia : Aluno
            builder.HasOne(r => r.Aluno)
                .WithMany(r => r.Resumos)
                .HasForeignKey(r => r.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ResumosDias");
        }
    }
}
