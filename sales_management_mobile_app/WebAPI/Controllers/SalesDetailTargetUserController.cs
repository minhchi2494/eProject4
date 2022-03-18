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
    public class SalesDetailTargetUserController : ControllerBase
    {
        private readonly ISalesDetailTargetUser _services;

        public SalesDetailTargetUserController(ISalesDetailTargetUser services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<vSalesDetailTargetUser>> getSalesDetailTargetUsers(DateTime? fromDate, DateTime? toDate)
        {
            return _services.getSalesDetailTargetUsers(fromDate, toDate);
        }
    }
}
