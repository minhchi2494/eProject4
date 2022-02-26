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
    public class TargetUserController : ControllerBase
    {
        private readonly ITargetUserServices _services;

        public TargetUserController(ITargetUserServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<vTargetUser>> getTargetUsers(DateTime? fromDate, DateTime? toDate)
        {
            return _services.getTargetUsers(fromDate, toDate);
        }
    }
}
