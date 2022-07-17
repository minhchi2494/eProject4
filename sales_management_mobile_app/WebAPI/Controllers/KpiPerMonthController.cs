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
    public class KpiPerMonthController : ControllerBase
    {
        private readonly KpiPerMonthServices _services;

        public KpiPerMonthController(KpiPerMonthServices services)
        {
            _services = services;
        }

        [HttpGet("{username}")]
        public Task<List<KpiPerMonth>> getManagers(string username)
        {
            return _services.getKpiPerMonths(username);
        }
    }
}
