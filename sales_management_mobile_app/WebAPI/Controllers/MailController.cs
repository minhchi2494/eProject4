using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Services.MailService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly LoginService loginService;
        public MailController(IMailService mailService, LoginService loginService)
        {
            this.mailService = mailService;
            this.loginService = loginService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMailRecoverPassword([FromForm] MailRequest request)
        {
            try
            {
                var findUser = loginService.checkAccountExist(request.UserName, request.ToEmail);
                if(findUser == true)
                {
                    loginService.generatePassword(request.UserName);
                    await mailService.sendPasswordViaEmail(request);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
