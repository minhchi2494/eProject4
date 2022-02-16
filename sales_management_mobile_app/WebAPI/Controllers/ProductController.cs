using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Product>> getProducts([FromQuery] Product searchProduct)
        {
            return _services.getProducts(searchProduct);
        }

        [HttpGet("{id}")]
        public Task<Product> getProduct(string id)
        {
            return _services.getProduct(id);
        }

        [HttpPost]
        public Task<bool> createProduct([FromBody]Product newProduct)
        {
            return _services.createProduct(newProduct);
        }

        [HttpPut]
        public Task<bool> updateProduct([FromBody]Product editProduct)
        {
            return _services.updateProduct(editProduct);
        }
    }
}
