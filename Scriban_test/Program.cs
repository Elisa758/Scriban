using System;
using Scriban;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.IO;

namespace Scriban_test
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new ProductContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var products = new List<Product>()
                {
                    new Product() { Name = "Licorne", Price = 15000 },
                    new Product() { Name = "Dragon", Price = 20000 },
                    new Product() { Name = "Pegaze", Price = 15000 },
                    new Product() { Name = "Tortue", Price = 15 },
                    new Product() { Name = "Crevette", Price = 1 },
                    new Product() { Name = "Hippocampe", Price = 5 },

                };
                context.AddRange(products);
                context.SaveChanges();
            }

            List<Product> ProductList = GetProducts();

            var html = ReadFile("../../../View/TemplateScriban.html");
            var template = Template.Parse(html);

            var result = template.Render(new { Products = ProductList });

            ProductController.WriteProducts(result);

        }
        public static string ReadFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            return reader.ReadToEnd(); 
        }

        public static List<Product> GetProducts()
        {
            using (var context = new ProductContext())
            {
                var products = (from p in context.Products
                                select p).ToList();
                return products;
            }
        }

    }
}
