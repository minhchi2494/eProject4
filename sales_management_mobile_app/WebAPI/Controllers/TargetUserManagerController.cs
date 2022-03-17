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
    public class TargetUserManagerController : ControllerBase
    {
        private readonly IPerformanceService _services;

        public TargetUserManagerController(IPerformanceService services)
        {
            _services = services;
        }

        [HttpGet]
        public List<Performance> getTargetUserManagers()
        {
            return _services.getAll();
        }
    }
}
