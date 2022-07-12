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
    public class KpiValueController : ControllerBase
    {
        private readonly IKpiValueServices _services;

        public KpiValueController(IKpiValueServices services)
        {
            _services = services;
        }

        [HttpPost("{dirId}/{kpiValue}")]
        public Task<bool> createValueKpi(string dirId, int kpiValue)
        {
            return _services.createKpiValue(dirId, kpiValue);
        }
    }
}
