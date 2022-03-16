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
    public class StoreUserController : ControllerBase
    {
        private readonly IStoreUserServices _services;

        public StoreUserController(IStoreUserServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vStoreUser>> getStoreUsers(int id)
        {
            return _services.getStoreUsers(id);
        }
    }
}
