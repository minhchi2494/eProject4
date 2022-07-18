using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerUserStoreServices
    {
        private readonly Project4Context _context;

        public ManagerUserStoreServices(Project4Context context)
        {
            _context = context;
        }
        public async Task<List<vManagerUserStore>> getManagerUserStores(string id)
        {
            var result = _context.vManagerUserStores.Where(x => x.ManagerId.Equals(id)).ToList();
            return result;
        }
    }
}
