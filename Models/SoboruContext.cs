using Microsoft.EntityFrameworkCore;

namespace SoboruApi.Models
{
    public class SoboruContext : DbContext
    {
        public SoboruContext(DbContextOptions<SoboruContext> options) : base(options) {

        }

        public DbSet<Medida> Medidas {get;set;}
    }
}