using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class SalesmanReportServices
    {
        private readonly Project4Context _context;

        public SalesmanReportServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vSalesmanReport>> getSalesmanReports()
        {
            var result = _context.vSalesmanReports.ToList();
            return result;
        }
    }
}
