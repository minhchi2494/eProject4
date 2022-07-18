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
    public class DirectorReportController : ControllerBase
    {
        private readonly DirectorReportServices _services;

        public DirectorReportController(DirectorReportServices services)
        {
            _services = services;
        }


        [HttpGet]
        public Task<List<vDirectorReport>> getDirectorReports()
        {
            return _services.getDirectorReports();
        }
    }
}
