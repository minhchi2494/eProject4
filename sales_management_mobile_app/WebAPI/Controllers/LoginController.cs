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
        private readonly LoginService _services;

        public LoginController(LoginService services)
        {
            _services = services;
        }

        [HttpPost("{username}/{password}")]
        public Object checkLogin( string username, string password)
        {
            return (object)_services.checkLogin(username, password);
        }
    }
}
