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
    public class ManagerUserStoreController : ControllerBase
    {
        private readonly ManagerUserStoreServices _services;

        public ManagerUserStoreController(ManagerUserStoreServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vManagerUserStore>> getManagerUserStores(string id)
        {
            return _services.getManagerUserStores(id);
        }
    }
}
