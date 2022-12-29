using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using WebAPI.Models;
using WebAPI.Services;
using System.IO;
using WebAPI.Requests;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;
        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "twinscloud";
        public const string API_KEY = "275761499984721";
        public const string API_SECRET = "80CMu92lwsKriZP5LqAiTu-EgH4";

        public UserController(IUserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<User>> getUsers([FromQuery] User searchUser)
        {
            return _services.getUsers(searchUser);
        }

        [HttpGet("{id}")]
        public Task<User> getUser(string id)
        {
            return _services.getUser(id);
        }

        [HttpPost("{username}/{password}")]
        public Task<User> checkLogin(string username, string password)
        {
            return _services.checkLogin(username, password);
        }

        [HttpPost]
        public async Task<bool> createUser([FromForm] UserRequest newUser)
        {
            Console.WriteLine(newUser.fullname);
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            User u = new User();
            u.Id = newUser.id;
            u.Username = newUser.username;
            u.Password = newUser.password;
            u.Fullname = newUser.fullname;
            u.Address = newUser.address;
            u.Email = newUser.email;
            u.Phone = newUser.phone;
            u.ManagerId = newUser.managerId;
            u.IsActive = newUser.isActive;
            if (newUser.file != null)
            {
                string filepath = Path.GetTempFileName();//get full path of file

                using (var stream = new FileStream(filepath, FileMode.Create))//copy path to stream to read path of file
                {
                    await newUser.file.CopyToAsync(stream);
                }

                //store to cloud
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filepath)
                };
                var uploadResult = cloudinary.Upload(uploadParams);

                u.Avatar = uploadResult.Url.ToString();
            }
            return await _services.createUser(u);
        }

        [HttpPut]
        public Task<bool> updateUser(string id, string oldPass, string Pass)
        {
            return _services.updateUser(id, oldPass, Pass);
        }
    }
}
