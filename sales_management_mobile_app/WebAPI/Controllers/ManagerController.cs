using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using WebAPI.Model;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        //private readonly IManagerServices _services;

        //public ManagerController(IManagerServices services)
        //{
        //    _services = services;
        //}

        //[HttpGet]
        //public Task<List<manager>> getManagers([FromQuery]manager searchManager)
        //{
        //    return _services.getManagers(searchManager);
        //}

        //[HttpPost]
        //public Task<bool> createManager([FromBody]manager newManager)
        //{
        //    return _services.createManager(newManager);
        //}

        //[HttpPut]
        //public Task<bool> updateManager(manager updateManager)
        //{
        //    return _services.updateManager(updateManager);
        //}
    }
}
