using SistemaPoc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaPoc.Data.Map
{
    public class ReclamanteMap : IEntityTypeConfiguration<Reclamante>
    {
        public void Configure(EntityTypeBuilder<Reclamante> builder)
        {
            builder.HasKey(advogado => advogado.Id);
            builder.Property(advogado => advogado.Nome).IsRequired().HasMaxLength(255);
            builder.Property(advogado => advogado.CPF).IsRequired().HasMaxLength(15);
        }
    }
}
