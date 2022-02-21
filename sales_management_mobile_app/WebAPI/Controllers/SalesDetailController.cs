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
    public class SalesDetailController : ControllerBase
    {
        private readonly ISalesDetailServices _services;

        public SalesDetailController(ISalesDetailServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<SalesDetail>> getSalesDetails(DateTime? fromDate, DateTime? toDate)
        {
            return _services.getSalesDetail(fromDate, toDate);
        }
    }
}
