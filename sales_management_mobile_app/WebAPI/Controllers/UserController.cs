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
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

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
        public Task<User> getUser(int id)
        {
            return _services.getUser(id);
        }

        [HttpPost("{username}/{password}")]
        public Task<User> checkLogin([FromQuery] string username, string password)
        {
            return _services.checkLogin(username, password);
        }

        [HttpPost]
        public Task<bool> createUser([FromBody] User newUser)
        {
            return _services.createUser(newUser);
        }

        [HttpPut]
        public Task<bool> updateUser([FromBody] User editUser)
        {
            return _services.updateUser(editUser);
        }
    }
}
