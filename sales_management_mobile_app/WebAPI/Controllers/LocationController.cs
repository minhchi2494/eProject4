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
    public class LocationController : ControllerBase
    {
        private readonly ILocationServices _services;

        public LocationController(ILocationServices services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Location>> getLocations([FromQuery] Location searchLoc)
        {
            return _services.getLocations(searchLoc);
        }

        [HttpGet("{id}")]
        public Task<Location> getLocation(int id)
        {
            return _services.getLocation(id);
        }

        [HttpPost]
        public Task<bool> createLocation([FromBody] Location location)
        {
            return _services.createLoc(location);
        }

        [HttpPut]
        public Task<bool> updateLocation([FromBody] Location location)
        {
            return _services.updateLoc(location);
        }
    }
}
