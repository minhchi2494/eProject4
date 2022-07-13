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
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _services;

        public LoginController(ILoginServices services)
        {
            _services = services;
        }

        //[HttpPost("{username}/{password}")]
        //public Task<Account> checkLogin([FromQuery] string username, string password)
        //{
        //    return _services.checkLogin(username, password);
        //}
    }
}
