using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class LoginServices : ILoginServices
    {
        public async Task<User> checkLogin(string username, string password)
        {
            //List<Director>
            //var model = _context.Users.Include(x => x.Manager).Where(x => x.IsActive == true).SingleOrDefault(a => a.Username.Equals(username));
            //if (model != null)
            //{
            //    string pass = PinCodeSecurity.pinDecrypt(model.Password);
            //    if (password.Equals(pass))
            //    {
            //        return model;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //else
            //{
            //    return null;
            //}
        }
    }
}
