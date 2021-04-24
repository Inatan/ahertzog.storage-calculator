using Microsoft.EntityFrameworkCore;
using Store.Calculator.Domain;

namespace Store.Calculator.Infrastructure
{
    public class DbEstoqueContext : DbContext
    {

        public DbEstoqueContext(): base()
        {
        }

        public DbEstoqueContext(DbContextOptions<DbEstoqueContext> options) :base(options)
        {
            
        }

        public DbSet<Material> EstoqueMaterias { get; set; }
        public DbSet<ValorServico> ValorServico { get; set; }

    }
}
