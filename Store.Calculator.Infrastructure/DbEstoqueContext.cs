using Microsoft.EntityFrameworkCore;
using Store.Calculator.Model;

namespace Store.Calculator.Infrastructure
{
    public class DbEstoqueContext : DbContext
    {
        public DbEstoqueContext(DbContextOptions options) : base(options)
        {

        }
        public DbEstoqueContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemomoryDatabase();
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DbStoreCalculator;Trusted_Connection=true");
        }

        public DbSet<EstoqueMateriaPrima> EstoqueMaterias { get; set; }
    }
}
