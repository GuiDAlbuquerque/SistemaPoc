using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPoc.Models;

namespace SistemaPoc.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(usuario => usuario.Id);
            builder.Property(usuario => usuario.Nome).IsRequired().HasMaxLength(255);
            builder.Property(usuario => usuario.Email).IsRequired().HasMaxLength(150);
        }
    }
}
