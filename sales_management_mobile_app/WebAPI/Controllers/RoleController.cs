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
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _services;

        public RoleController(IRoleServices services)
        {
            _services = services;
        }

        //[HttpGet]
        //public Task<List<Role>> getRoles([FromQuery] Role searchRole)
        //{
        //    return _services.getRoles(searchRole);
        //}

        //[HttpGet("{id}")]
        //public Task<Role> getRole(int id)
        //{
        //    return _services.getRole(id);
        //}

        //[HttpPost]
        //public Task<bool> createRole([FromBody] Role newRole)
        //{
        //    return _services.createRole(newRole);
        //}

        //[HttpPut]
        //public Task<bool> updateRole(Role updateRole)
        //{
        //    return _services.updateRole(updateRole);
        //}
    }
}
