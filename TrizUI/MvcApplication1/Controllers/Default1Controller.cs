using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProductsController : ApiController
    {

        IList<Product> pds = new List<Product>{
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };
        // GET api/Products
        //[Route("api/Products/users-{spaceUserId}/{pageIndex=1}/{pageSize=20}")]
        public IEnumerable<Product> Get()
        {
            return pds;
        }

        // GET api/Products/5
        public IEnumerable<Product> Get([FromUri]string currentPage, int itemsPerPage)
        {
            IList<Product> pds1 = new List<Product>{
            new Product { Id = 1, Name = currentPage, Category = "bbb", Price = 1 },
            new Product { Id = 2, Name = itemsPerPage.ToString(), Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 4, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 5, Name = "Hammer", Category = "Hardware", Price = 16.99M }
            };
            return pds1;
        }
        //public IHttpActionResult Get(int id)
        //{
        //    var product = pds.FirstOrDefault((p) => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        // POST api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Products/5
        public void Delete(int id)
        {
            int aaa = id;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
