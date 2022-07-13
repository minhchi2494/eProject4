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
        private readonly Project4Context _context;
        public LoginServices(Project4Context context)
        {
            _context = context;
        }

        //public async Task<Account> checkLogin(string username, string password)
        //{
            
        //}
    }
}

