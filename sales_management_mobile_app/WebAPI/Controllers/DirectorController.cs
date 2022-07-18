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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorServices _services;

        public DirectorController(IDirectorServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Director>> getDirectors([FromQuery] Director searchDirector)
        {
            return _services.getDirectors(searchDirector);
        }

        [HttpGet("{id}")]
        public Task<Director> getDirector(string id)
        {
            return _services.getDirector(id);
        }

        [HttpPost("{username}/{password}")]
        public Task<Director> checkLogin([FromQuery] string username, string password)
        {
            return _services.checkLogin(username, password);
        }

        [HttpPost]
        public Task<bool> createDirector([FromBody] Director newDirector)
        {
            return _services.createDirector(newDirector);
        }

        [HttpPut]
        public Task<bool> updateDirector(string id, string oldPass, string Pass)
        {
            return _services.updateDirector(id, oldPass, Pass);
        }
    }
}
