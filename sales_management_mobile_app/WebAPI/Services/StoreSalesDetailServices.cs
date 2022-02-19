using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class StoreSalesDetailServices : IStoreSalesDetailServices
    {
        private readonly Project4Context _context;

        public StoreSalesDetailServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<StoreSalesDetail>> getStoreSalesDetails(StoreSalesDetail searchStoreSalesDetail, DateTime? fromDate, DateTime? toDate)
        {
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store)
                                              .Where(x => x.Date >= fromDate).Where(x => x.Date <= toDate).ToList();
                return result;
            }
        }
    }
}
