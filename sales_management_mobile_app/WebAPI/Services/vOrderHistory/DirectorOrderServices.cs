using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class DirectorOrderServices
    {
        private readonly Project4Context _context;

        public DirectorOrderServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vOrderHistory>> getDirectorOrders(string id)
        {
            var result = _context.vOrderHistories.Where(x => x.DirectorId.Equals(id)).ToList();
            return result;
        }
    }
}
