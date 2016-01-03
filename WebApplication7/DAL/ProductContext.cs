using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Http;
using WebApplication7.Models;
using System.Linq;
using System.Web.DynamicData;
using System.Web.UI.WebControls.Expressions;

namespace WebApplication7.DAL
{
    public static class ContextHelper
    {
        public static TResult DoAndSave<TResult>(this DbContext context, Func<TResult> action)
        {
            var result = action();
            context.SaveChanges();
            return result;
        }
    }

    public class ProductContext : DbContext
    {

        public ProductContext() : base("ProductContext") {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            => modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
}