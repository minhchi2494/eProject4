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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerServices _services;

        public ManagerController(IManagerServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Manager>> getManagers([FromQuery] Manager searchManager)
        {
            return _services.getManagers(searchManager);
        }

        [HttpGet("{id}")]
        public Task<Manager> getManager(string id)
        {
            return _services.getManager(id);
        }

        [HttpPost]
        public Task<bool> createManager([FromBody] Manager newManager)
        {
            return _services.createManager(newManager);
        }

        [HttpPut]
        public Task<bool> updateManager(Manager updateManager)
        {
            return _services.updateManager(updateManager);
        }
    }
}
