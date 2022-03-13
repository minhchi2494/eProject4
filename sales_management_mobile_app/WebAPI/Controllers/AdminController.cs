using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
        public class AdminController : ControllerBase
    {
        private readonly IAdminServices _services;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AdminController(IAdminServices services, IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _services = services;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var admin = _services.Authenticate(model.Username, model.Password);

            if (admin == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = admin.Id,
                Username = admin.Username,
                Fullname = admin.Fullname,
                Phone = admin.Phone,
                Token = tokenString
            });
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var admin = _mapper.Map<Admin>(model);

            try
            {
                // create user
                _services.Create(admin, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }





        [HttpGet]
        public IActionResult GetAll()
        {
            var admins = _services.GetAll();
            var model = _mapper.Map<IList<AdminModel>>(admins);
            return Ok(model);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var admin = _services.getAdmin(id);
            var model = _mapper.Map<AdminModel>(admin);
            return Ok(model);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            // map model to entity and set id
            var admin = _mapper.Map<Admin>(model);
            admin.Id = id;

            try
            {
                // update user 
                _services.Update(admin, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _services.Delete(id);
            return Ok();
        }

        //[HttpPost("{username}/{password}")]
        //public Task<Admin> checkLogin([FromForm] string username, string password)
        //{
        //    return _services.checkLogin(username, password);
        //}

        //[HttpGet]
        //public Task<List<Admin>> getAdmins()
        //{
        //    return _services.getAdmins();
        //}

        //[HttpGet("{id}")]
        //public Task<Admin> getAdmin(int id)
        //{
        //    return _services.getAdmin(id);
        //}

        //[HttpPost]
        //public Task<bool> createAdmin([FromBody]Admin newAdmin)
        //{
        //    return _services.createAdmin(newAdmin);
        //}

        //[HttpPut]
        //public Task<bool> updateAdmin([FromBody] Admin editAdmin)
        //{
        //    return _services.updateAdmin(editAdmin);
        //}
    }
}
