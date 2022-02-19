using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class SalesDetailServices : ISalesDetailServices
    {
        private readonly Project4Context _context;

        public SalesDetailServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<SalesDetail>> getSalesDetail(SalesDetail searchSalesDetail, DateTime? fromDate, DateTime? toDate)
        {
            var result = _context.SalesDetails.Include(x => x.Target).Include(x => x.Product).ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                result = _context.SalesDetails.Include(x => x.Target).Include(x => x.Product)
                                              .Where(x => x.Date >= fromDate).Where(x => x.Date <= toDate).ToList();
                return result;
            }
        }
    }
}
