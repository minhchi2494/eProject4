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
    public class ManagerOrderController : ControllerBase
    {
        private readonly ManagerOrderServices _services;

        public ManagerOrderController(ManagerOrderServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vOrderHistory>> getManagerOrders(string id)
        {
            return _services.getManagerOrders(id);
        }
    }
}
