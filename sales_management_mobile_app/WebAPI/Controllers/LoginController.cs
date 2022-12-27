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
        private readonly KpiPerMonthServices _kpiPerMonthServices;

        public LoginController(LoginService services, KpiPerMonthServices kpiPerMonthServices)
        {
            _services = services;
            _kpiPerMonthServices = kpiPerMonthServices;
        }
        /*("{username}/{password}")*/
        [HttpGet("{username}/{password}")]
        public Object checkLogin( string username, string password)
        {
            _kpiPerMonthServices.saveKpiPerMonth();
            return (object)_services.checkLogin(username, password);
        }
        [Route("/reset-password/{username}/{pinCode}/{newPassword}")]
        [HttpPut]
        public string resetPassword(string username, int pinCode, string newPassword)
        {
            return _services.resetPassword(username, pinCode, newPassword);
        }
    }
}
