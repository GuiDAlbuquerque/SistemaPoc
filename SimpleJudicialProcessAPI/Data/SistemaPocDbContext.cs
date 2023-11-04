using Microsoft.EntityFrameworkCore;
using SistemaPoc.Data.Map;
using SistemaPoc.Models;

namespace SistemaPoc.Data
{
    public class SistemaPocDbContext : DbContext
    {
        public SistemaPocDbContext(DbContextOptions<SistemaPocDbContext> options) 
            : base(options) 
        { 

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Processo> Processo { get; set; }
        public DbSet<Advogado> Advogado { get; set; }
        public DbSet<Reclamante> Reclamante { get; set; }
        public DbSet<Reclamada> Reclamada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AdvogadoMap());
            modelBuilder.ApplyConfiguration(new ReclamadaMap());
            modelBuilder.ApplyConfiguration(new ReclamanteMap());
            modelBuilder.ApplyConfiguration(new ProcessoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
