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
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _services;

        public AdminController(IAdminServices services)
        {
            _services = services;
        }

        [HttpGet("{username}/{password}")]
        public Task<Admin> checkLogin([FromQuery]string username, string password)
        {
            return _services.checkLogin(username, password);
        }

        [HttpGet]
        public Task<List<Admin>> getAdmins()
        {
            return _services.getAdmins();
        }

        [HttpGet("{id}")]
        public Task<Admin> getAdmin(int id)
        {
            return _services.getAdmin(id);
        }

        [HttpPost]
        public Task<bool> createAdmin([FromBody]Admin newAdmin)
        {
            return _services.createAdmin(newAdmin);
        }

        [HttpPut]
        public Task<bool> updateAdmin([FromBody] Admin editAdmin)
        {
            return _services.updateAdmin(editAdmin);
        }
    }
}
