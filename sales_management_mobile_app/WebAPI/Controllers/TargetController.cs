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
    public class TargetController : ControllerBase
    {
        private readonly ITargetServices _services;

        public TargetController(ITargetServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Target>> getTargets()
        {
            return _services.getTargets();
        }
    }
}
