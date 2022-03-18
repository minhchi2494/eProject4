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
        private readonly ITargetUserManagerServices _services;

        public TargetUserManagerController(ITargetUserManagerServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<vTargetUserManager>> getTargetUserManagers(DateTime? fromDate, DateTime? toDate)
        {
            return _services.getTargetUserManagers(fromDate, toDate);
        }
    }
}
