using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Services;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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

        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "da85i8t2o";
        public const string API_KEY = "782372915787355";
        public const string API_SECRET = "6peu85e37dcz83v7zrm8IsX3d5k";

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
        public Task<bool> createProduct([FromForm] Requests.ProductRequest request)
        {
            //IFormFile file = request.file;
            //Product newProduct = new Product();
            //newProduct.Id = request.id;
            //newProduct.Name = request.name;
            //newProduct.Price = request.price;
            //newProduct.Description = request.description;
            //newProduct.IsActive = request.active;

            //if (file != null)
            //{
            //    var dictPath = Path.Combine(_hostEnvironment.ContentRootPath, "Upload");
            //    var filepath = Path.Combine(dictPath, file.FileName);
            //    using(var stream = new FileStream(filepath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //    newProduct.Images = "/Upload/" + file.FileName;
            //}

            //return _services.createProduct(newProduct);
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            IFormFile file = request.file;
            Product newProduct = new Product();
            newProduct.Id = request.id;
            newProduct.Name = request.name;
            newProduct.Price = request.price;
            newProduct.Description = request.description;
            newProduct.IsActive = request.active;

            if (file != null)
            {
                var dictPath = Path.Combine(_hostEnvironment.ContentRootPath, "Upload");
                var filepath = Path.Combine(dictPath, file.FileName);

                //var imagePath = filepath;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filepath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                newProduct.Images = uploadResult.Url.ToString(); 
            }
            return _services.createProduct(newProduct);

        }


        [HttpPut]
        public Task<bool> updateProduct([FromForm] Requests.ProductRequest request)
        {
            IFormFile file = request.file;
            Product editProduct = new Product();
            editProduct.Id = request.id;
            editProduct.Name = request.name;
            editProduct.Price = request.price;
            editProduct.Description = request.description;
            editProduct.IsActive = request.active;

            Task<Product> pro = _services.getProduct(request.id);
            Product p = pro.Result;


            if (file != null)
            {
                var dicPath = Path.Combine(_hostEnvironment.ContentRootPath, "Upload");
                var filePath = Path.Combine(dicPath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                editProduct.Images = "/Upload/" + file.FileName;
            }
            else if (file == null)
            {
                editProduct.Images = p.Images;
            }
            return _services.updateProduct(editProduct);
        }
    }
}
