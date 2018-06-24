using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SoboruApi.Models
{
    public class SoboruContext : DbContext
    {
        public SoboruContext(DbContextOptions<SoboruContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ReceitaUtensilio>()
                .HasKey(t => new {t.ReceitaId, t.UtensilioId});
            
            modelBuilder.Entity<ReceitaUtensilio>()
                .HasOne(ru => ru.Receita)
                .WithMany(r => r.ReceitasUtensilios)
                .HasForeignKey(ru => ru.ReceitaId);
            
            modelBuilder.Entity<ReceitaUtensilio>()
                .HasOne(ru => ru.Utensilio)
                .WithMany(u => u.ReceitasUtensilios)
                .HasForeignKey(ru => ru.UtensilioId);
        }

        public DbSet<Medida> Medidas {get;set;}
        public DbSet<Receita> Receitas {get;set;}
        public DbSet<Utensilio> Utensilios {get;set;}
    }
}