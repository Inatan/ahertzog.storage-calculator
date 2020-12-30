using System;

namespace Store.Calculator.Infrastructure.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed(DbEstoqueContext ctx)
        {
            try
            {
                if (ctx.Database.EnsureCreated())
                { 
                
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
