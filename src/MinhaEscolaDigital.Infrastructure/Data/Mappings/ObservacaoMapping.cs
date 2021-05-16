using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscolaDigital.Domain.Entities;

namespace MinhaEscolaDigital.Infrastructure.Data.Mapping
{
    public class ObservacaoConfigurations : IEntityTypeConfiguration<Observacao>
    {
        public void Configure(EntityTypeBuilder<Observacao> builder)
        {

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Texto)
                .IsRequired()
                .HasColumnType("varchar(8000)");

            builder.ToTable("Observacoes");

        }
    }
}
