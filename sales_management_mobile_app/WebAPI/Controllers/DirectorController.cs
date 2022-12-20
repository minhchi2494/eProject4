using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorServices _services;
        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "twinscloud";
        public const string API_KEY = "275761499984721";
        public const string API_SECRET = "80CMu92lwsKriZP5LqAiTu-EgH4";

        public DirectorController(IDirectorServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Director>> getDirectors([FromQuery] Director searchDirector)
        {
            return _services.getDirectors(searchDirector);
        }

        [HttpGet("{id}")]
        public Task<Director> getDirector(string id)
        {
            return _services.getDirector(id);
        }

        [HttpPost("{username}/{password}")]
        public Task<Director> checkLogin([FromQuery] string username, string password)
        {
            return _services.checkLogin(username, password);
        }

        [HttpPost]
        public async Task<bool> createDirector([FromQuery] Director newDirector, IFormFile file)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            if (file != null)
            {
                string filepath = Path.GetTempFileName();//get full path of file

                using (var stream = new FileStream(filepath, FileMode.Create))//copy path to stream to read path of file
                {
                    await file.CopyToAsync(stream);
                }

                //store to cloud
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filepath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                newDirector.Avatar = uploadResult.Url.ToString();
            }
            return await _services.createDirector(newDirector);
        }

        [HttpPut]
        public Task<bool> updateDirector(string id, string oldPass, string Pass)
        {
            return _services.updateDirector(id, oldPass, Pass);
        }
    }
}
