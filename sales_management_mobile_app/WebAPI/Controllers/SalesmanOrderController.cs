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
    public class SalesmanOrderController : ControllerBase
    {
        private readonly SalesmanOrderServices _services;

        public SalesmanOrderController(SalesmanOrderServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vOrderHistory>> getSalesmanOrders(int id)
        {
            return _services.getSalesmanOrders(id);
        }
    }
}
