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
    public class ManagerUserController : ControllerBase
    {
        private readonly IManagerUserServices _services;

        public ManagerUserController(IManagerUserServices services)
        {
            _services = services;
        }

        //[HttpGet]
        //public Task<List<vManagerUser>> getManagerUsers([FromQuery] vManagerUser managerUser)
        //{
        //    return _services.getManagerUsers(managerUser);
        //}

        [HttpGet("{id}")]
        public Task<List<vManagerUser>> getManagerUsers(string id)
        {
            return _services.getManagerUsers(id);
        }
    }
}
