using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class SalesmanOrderServices
    {
        private readonly Project4Context _context;

        public SalesmanOrderServices(Project4Context context)
        {
            _context = context;
        }
        public async Task<List<vOrderHistory>> getSalesmanOrders(int id)
        {
            var result = _context.vOrderHistories.Where(x => x.SalesmanId.Equals(id)).ToList();
            return result;
        }

    }
}
