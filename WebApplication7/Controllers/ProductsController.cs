using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using WebApplication7.DAL;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductContext context
            = new ProductContext();

        public IEnumerable<Product> Get()
            => context.Products;

        [NullResponseIs404]
        public Product Get(int id)
            => context.Products.SingleOrDefault(p => p.Id == id);

        public Product Post([FromBody] Product product)
        {
            context.Products.AddOrUpdate(product);
            context.SaveChanges();
            return product;
        }
    }
}
