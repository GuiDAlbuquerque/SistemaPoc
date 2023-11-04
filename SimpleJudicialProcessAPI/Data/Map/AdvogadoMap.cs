using SistemaPoc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaPoc.Data.Map
{
    public class AdvogadoMap : IEntityTypeConfiguration<Advogado>
    {
        public void Configure(EntityTypeBuilder<Advogado> builder)
        {
            builder.HasKey(advogado => advogado.Id);
            builder.Property(advogado => advogado.Nome).IsRequired().HasMaxLength(255);
            builder.Property(advogado => advogado.OAB).IsRequired().HasMaxLength(15);
        }
    }
}
