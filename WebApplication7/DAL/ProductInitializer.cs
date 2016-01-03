using System;
using System.Collections.Generic;
using WebApplication7.Models;

namespace WebApplication7.DAL
{
    public class ProductInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            context.Products.Add(new Product { Name = "Tomato Soup", Category = "Groceries", Price = 1m });
            context.Products.Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75m });
            context.Products.Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99m });
            context.SaveChanges();
        }
    }
}
