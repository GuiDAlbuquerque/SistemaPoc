using SistemaPoc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaPoc.Data.Map
{
    public class ReclamadaMap : IEntityTypeConfiguration<Reclamada>
    {
        public void Configure(EntityTypeBuilder<Reclamada> builder)
        {
            builder.HasKey(advogado => advogado.Id);
            builder.Property(advogado => advogado.Nome).IsRequired().HasMaxLength(255);
            builder.Property(advogado => advogado.CNPJ).IsRequired().HasMaxLength(30);
        }
    }
}
