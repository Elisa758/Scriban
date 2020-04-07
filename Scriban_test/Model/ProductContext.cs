using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace Scriban_test
{
    public class ProductContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Product_Scriban;Integrated Security=True;MultipleActiveResultSets=true");
        }
    }
}
