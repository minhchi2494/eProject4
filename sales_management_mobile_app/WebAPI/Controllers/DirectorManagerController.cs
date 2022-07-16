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
    public class DirectorManagerController : ControllerBase
    {
        private readonly IDirectorManager _services;

        public DirectorManagerController(IDirectorManager services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public Task<List<vDirectorManager>> getDirectorManagers(string id)
        {
            return _services.getDirectorManagers(id);
        }
    }
}
