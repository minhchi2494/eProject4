using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class StoreUserServices : IStoreUserServices
    {
        private readonly Project4Context _context;

        public StoreUserServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vStoreUser>> getStoreUsers(int id)
        {
            var result = _context.vStoreUser.Where(x => x.Id.Equals(id)).ToList();
            return result;
        }
    }
}
