using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class UserStoreServices : IUserStoreServices
    {
        private readonly Project4Context _context;

        public UserStoreServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vUserStore>> getUserStores(int id)
        {
            var result = _context.vUserStores.Where(x => x.Id.Equals(id)).ToList();
            return result;
        }
    }
}
