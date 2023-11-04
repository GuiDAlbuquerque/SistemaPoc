using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPoc.Models;
using System.Diagnostics;

namespace SistemaPoc.Data.Map
{
    public class ProcessoMap : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {
            builder.HasKey(processo => processo.Id);
            builder.Property(processo => processo.CNPJ).IsRequired().HasMaxLength(100);
            builder.Property(processo => processo.AdvogadoId).IsRequired();
            builder.Property(processo => processo.ReclamanteId).IsRequired();
            builder.Property(processo => processo.ReclamadaId).IsRequired();
            builder.Property(processo => processo.UsuarioId).IsRequired();
        }
    }
}
