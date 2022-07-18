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
    public class ManagerReportController : ControllerBase
    {
        private readonly ManagerReportServices _services;

        public ManagerReportController(ManagerReportServices services)
        {
            _services = services;
        }


        [HttpGet]
        public Task<List<vManagerReport>> getManagerReports()
        {
            return _services.getManagerReports();
        }
    }
}
