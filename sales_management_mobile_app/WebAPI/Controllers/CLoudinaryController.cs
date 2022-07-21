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
    public class CLoudinaryController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "da85i8t2o";
        public const string API_KEY = "782372915787355";
        public const string API_SECRET = "6peu85e37dcz83v7zrm8IsX3d5k";

        public CLoudinaryController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        public async Task<bool> postImage([FromForm] ImageCloudinary request)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            IFormFile file = request.file;

            if (file != null)
            {
                var dictPath = Path.Combine(_hostEnvironment.ContentRootPath, "Upload");
                var filepath = Path.Combine(dictPath, file.FileName);

                var imagePath = filepath;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imagePath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                var url = uploadResult.Url.ToString(); 
            }

            return true;
        }
    }
}
