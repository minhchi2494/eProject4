using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerOrderServices
    {
        private readonly Project4Context _context;

        public ManagerOrderServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vOrderHistory>> getManagerOrders(string id)
        {
            var result = _context.vOrderHistories.Where(x => x.ManagerId.Equals(id)).ToList();
            return result;
        }
    }
}
