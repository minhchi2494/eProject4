using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Services;


//test create product
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductServices services, IWebHostEnvironment hostEnvironment)
        {
            _services = services;
            _hostEnvironment = hostEnvironment;
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
        public Task<bool> createProduct([FromQuery] Product newProduct)
        {
            return _services.createProduct(newProduct);
        }

        //[HttpPost]
        //public async Task<bool> createProduct([FromQuery]Product2 product2)
        //{
        //    var product = await _services.createProduct(new Product()
        //    {
        //        Id = product2.Id,
        //        Name = product2.Name,
        //        Price = product2.Price,
        //        Unit = product2.Unit,
        //        Images = product2.Images,
        //        IsActive = product2.IsActive,
        //    });
        //    return true;
        //}

        //[NonAction]
        //public async Task<string> SaveImage(IFormFile imageFile)
        //{
        //    string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ','-');
        //    imageName = imageName + Path.GetExtension(imageFile.FileName);
        //    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
        //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream);
        //    }
        //    return imageName;
        //}

        [HttpPut]
        public Task<bool> updateProduct([FromQuery]Product editProduct)
        {
            return _services.updateProduct(editProduct);
        }
    }
}
