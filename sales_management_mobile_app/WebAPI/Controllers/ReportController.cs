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
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _services;

        public ReportController(IReportServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Report>> getReports([FromQuery] DateTime? fromDate, DateTime? toDate)
        {
            return _services.getReports(fromDate, toDate);
        }
    }
}
