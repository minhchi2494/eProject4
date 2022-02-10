using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly Project4Context _context;

        public UserServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<User>> getUsers(User searchUser)
        {
            var result = _context.Users.Include(a=>a.Location).Include(a=>a.Manager).Include(a => a.Role).Include(a => a.Store).Include(a => a.Target)
                .Where(x=>x.IsActive == true).ToList();
            if (!string.IsNullOrEmpty(searchUser.Fullname))
            {
                result = result.Where(x=>x.Fullname.ToLower().Contains(searchUser.Fullname.ToLower())).ToList();
            }
            return result;
        }
    }
}
