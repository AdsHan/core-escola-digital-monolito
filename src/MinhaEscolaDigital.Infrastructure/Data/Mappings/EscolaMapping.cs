using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscolaDigital.Domain.DomainObjects;
using MinhaEscolaDigital.Domain.Entities;

namespace MinhaEscolaDigital.Infrastructure.Data.Mapping
{
    public class EscolaMapping : IEntityTypeConfiguration<Escola>
    {
        public void Configure(EntityTypeBuilder<Escola> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.OwnsOne(c => c.Cnpj, tf =>
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Cnpj.CnpjMaxLength)
                    .HasColumnName("Cpnj")
                    .HasColumnType($"varchar({Cnpj.CnpjMaxLength})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasMaxLength(Email.EnderecoMaxLength)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.OwnsOne(c => c.Telefone, tf =>
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.TelefoneMaxLength)
                    .HasColumnName("Telefone")
                    .HasColumnType($"varchar({Telefone.TelefoneMaxLength})");
            });

            builder.OwnsOne(c => c.Celular, tf =>
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Telefone.TelefoneMaxLength)
                    .HasColumnName("Celular")
                    .HasColumnType($"varchar({Telefone.TelefoneMaxLength})");
            });

            // 1 : 1 => Escola : Endereco
            builder.HasOne(e => e.Endereco).WithOne();

            // 1 : 1 => Escola : Observacao
            builder.HasOne(e => e.Endereco).WithOne();

            // 1 : N => Escola : Turma
            builder.HasMany(e => e.Turmas)
                .WithOne(t => t.Escola)
                .HasForeignKey(t => t.EscolaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Escolas");

        }
    }
}
