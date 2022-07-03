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
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _services;

        public OrderController(IOrderServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Order>> getOrders([FromQuery] DateTime? fromDate, DateTime? toDate)
        {
            return _services.getOrders(fromDate, toDate);
        }

        [HttpGet("{id}")]
        public Task<Order> getOrder(int id)
        {
            return _services.getOrder(id);
        }
    }
}
