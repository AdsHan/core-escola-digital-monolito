using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Entities;

namespace MinhaEscolaDigital.Infrastructure.Data.Mapping
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(a => a.Rg, tf =>
            {
                tf.Property(a => a.Numero)
                    .HasMaxLength(Rg.RgMaxLength)
                    .HasColumnName("Rg")
                    .HasColumnType($"varchar({Rg.RgMaxLength})");
            });

            builder.OwnsOne(a => a.Cpf, tf =>
            {
                tf.Property(a => a.Numero)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            // 1 : 1 => Aluno : Endereco
            builder.HasOne(a => a.Endereco).WithOne();

            // 1 : 1 => Aluno : Observacao
            builder.HasOne(a => a.Observacao).WithOne();

            // 1 : N => Aluno : Resumo Dia
            builder.HasMany(a => a.Resumos)
                .WithOne(t => t.Aluno)
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            // N : 1 => Aluno : Turma
            builder.HasOne(a => a.Turma)
                .WithMany(t => t.Alunos)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Alunos");
        }
    }
}
