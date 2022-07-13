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
    public class UserStoreController : ControllerBase
    {
        private readonly IUserStoreServices _services;

        public UserStoreController(IUserStoreServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vUserStore>> getUserStores(int id)
        {
            return _services.getUserStores(id);
        }
    }
}
