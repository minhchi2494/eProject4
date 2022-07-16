using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ReportServices : IReportServices
    {
        private readonly Project4Context _context;

        public ReportServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Report>> getReports(DateTime? fromDate, DateTime? toDate)
        {
            var result = _context.Reports.ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                result = _context.Reports.Where(x => x.CreatedOn >= fromDate).Where(x => x.CreatedOn <= toDate).ToList();
                return result;
            }
        }
    }
}
