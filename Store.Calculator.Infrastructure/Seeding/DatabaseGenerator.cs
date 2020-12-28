using System;

namespace Store.Calculator.Infrastructure.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            try
            {
                using (var ctx = new DbEstoqueContext())
                {
               
                    if (ctx.Database.EnsureCreated())
                    { 
                
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
