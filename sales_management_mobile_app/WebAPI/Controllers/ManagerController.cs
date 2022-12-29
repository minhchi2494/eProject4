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
using WebAPI.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerServices _services;
        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "twinscloud";
        public const string API_KEY = "275761499984721";
        public const string API_SECRET = "80CMu92lwsKriZP5LqAiTu-EgH4";

        public ManagerController(IManagerServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Manager>> getManagers([FromQuery] Manager searchManager)
        {
            return _services.getManagers(searchManager);
        }

        [HttpPost("{username}/{password}")]
        public Task<Manager> checkLogin([FromQuery] string username, string password)
        {
            return _services.checkLogin(username, password);
        }

        [HttpGet("{id}")]
        public Task<Manager> getManager(string id)
        {
            return _services.getManager(id);
        }

        [HttpPost]
        public async Task<bool> createManager([FromForm] ManagerRequest newManager)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            Manager u = new Manager();
            u.Id = newManager.id;
            u.Username = newManager.username;
            u.Password = newManager.password;
            u.Fullname = newManager.fullname;
            u.Address = newManager.address;
            u.Email = newManager.email;
            u.Phone = newManager.phone;
            u.DirectorId = newManager.directorId;
            u.IsActive = newManager.isActive;
            if (newManager.file != null)
            {
                string filepath = Path.GetTempFileName();//get full path of file

                using (var stream = new FileStream(filepath, FileMode.Create))//copy path to stream to read path of file
                {
                    await newManager.file.CopyToAsync(stream);
                }

                //store to cloud
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filepath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                u.Avatar = uploadResult.Url.ToString();
            }
            return await _services.createManager(u);
        }

        [HttpPut]
        public Task<bool> updateManager(string id, string oldPass, string Pass)
        {
            return _services.updateManager(id, oldPass, Pass);
        }
    }
}
