﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Calculator.Infrastructure.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var ctx = new DbEstoqueContext())
            {
                if (ctx.Database.EnsureCreated())
                {
                
                }
            }
        }
    }
}