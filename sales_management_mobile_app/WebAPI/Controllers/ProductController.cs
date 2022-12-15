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
using WebAPI.Requests;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.Cloudinary;

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
        //public const string CLOUD_NAME = "twinscloud";
        //public const string API_KEY = "275761499984721";
        //public const string API_SECRET = "80CMu92lwsKriZP5LqAiTu-EgH4";



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
        public async Task<bool> createProduct([FromForm] ProductRequest product)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            Product newProduct = new Product();
            newProduct.Id = product.id;
            newProduct.Name = product.name;
            newProduct.Price = product.price;
            newProduct.Description = product.description;
            newProduct.IsActive = product.active;

            if (product.file != null)
            {
                string filepath = Path.GetTempFileName();//get full path of file

                using (var stream = new FileStream(filepath, FileMode.Create))//copy path to stream to read path of file
                {
                    await product.file.CopyToAsync(stream);
                }


                //store to cloud
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filepath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                newProduct.Images = uploadResult.Url.ToString();
            }
            return await _services.createProduct(newProduct);

        }


        [HttpPut]
        public async Task<ActionResult<Product>> updateProduct([FromQuery] ProductRequest product)
        {
            try
            {
                Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
                cloudinary = new Cloudinary(account);

                Product editProduct = _services.getProduct(product.id).Result;
                if (editProduct == null)
                {
                    return NotFound();
                }


                editProduct.Id = product.id;
                editProduct.Name = product.name;
                editProduct.Price = product.price;
                editProduct.Description = product.description;
                editProduct.IsActive = product.active;

                if (product.file != null)
                {
                    string filepath = Path.GetTempFileName();//get full path of file
                    Console.WriteLine(filepath);
                    using (var stream = new FileStream(filepath, FileMode.Create))//copy path to stream to read path of file
                    {
                        await product.file.CopyToAsync(stream);
                    }

                    //store to cloud
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(filepath)
                    };
                    Console.WriteLine(uploadParams.ToString());
                    Console.WriteLine(filepath);
                    var uploadResult = cloudinary.Upload(uploadParams);

                    editProduct.Images = uploadResult.Url.ToString(); ;
                }
                else
                {
                    editProduct.Images = editProduct.Images;
                }


                return await _services.updateProduct(editProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [Route("/get-inventory")]
        [HttpGet]
        public List<Product> getInvetory()
        {
            return _services.getInventory();
        }
    }
}
