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
    public class DirectorOrderController : ControllerBase
    {
        private readonly DirectorOrderServices _services;

        public DirectorOrderController(DirectorOrderServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vOrderHistory>> getDirectorOrders(string id)
        {
            return _services.getDirectorOrders(id);
        }
    }
}
