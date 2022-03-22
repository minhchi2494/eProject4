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
    public class StoreSalesDetailController : ControllerBase
    {
        private readonly IStoreSalesDetailServices _services;

        public StoreSalesDetailController(IStoreSalesDetailServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<StoreSalesDetail>> getStoreSalesDetails([FromQuery]DateTime? fromDate, DateTime? toDate)
        {
            return _services.getStoreSalesDetails(fromDate, toDate);
        }

        [HttpPost]
        public Task<bool> createActualQuantity([FromQuery] string productId,[FromQuery] StoreSalesDetail ssd)
        {
            return _services.createActualQuantity(productId, ssd);
        }

        [HttpGet("{id}")]
        public Task<StoreSalesDetail> getStoreSalesDetail(int id)
        {
            return _services.getStoreSalesDetail(id);
        }
    }
}
