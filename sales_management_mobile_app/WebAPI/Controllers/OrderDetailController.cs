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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailServices _services;

        public OrderDetailController(IOrderDetailServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<OrderDetail>> getOrderDetails()
        {
            return _services.getOrderDetails();
        }

        [HttpPost]
        public Task<bool> createActualQuantity([FromBody] OrderDetail ssd)
        {
            return _services.createActualQuantity(ssd);
        }

        [HttpGet("{id}")]
        public Task<OrderDetail> getOrderDetails(int id)
        {
            return _services.getOrderDetail(id);
        }
    }
}
