using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaEscolaDigital.Domain.Entities;

namespace MinhaEscolaDigital.Infrastructure.Data.Mapping
{
    public class ObservacaoConfigurations : IEntityTypeConfiguration<Observacao>
    {
        public void Configure(EntityTypeBuilder<Observacao> builder)
        {

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Texto)
                .IsRequired()
                .HasColumnType("varchar(8000)");

            builder.ToTable("Observacoes");

        }
    }
}
