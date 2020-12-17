using Microsoft.EntityFrameworkCore;
using Store.Calculator.Model;

namespace Store.Calculator.Infrastructure
{
    public class DbEstoqueContext : DbContext
    {
        public DbSet<EstoqueMateriaPrima> EstoqueMaterias { get; set; }

        public DbEstoqueContext(DbContextOptions<DbEstoqueContext> options): base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DbStoreCalculator;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstoqueMateriaPrima>();
        }

    }
}
