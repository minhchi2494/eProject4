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
    public class SalesmanReportController : ControllerBase
    {
        private readonly SalesmanReportServices _services;

        public SalesmanReportController(SalesmanReportServices services)
        {
            _services = services;
        }


        [HttpGet]
        public Task<List<vSalesmanReport>> getSalesmanReports()
        {
            return _services.getSalesmanReports();
        }
    }
}
