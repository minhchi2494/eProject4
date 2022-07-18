using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerReportServices
    {
        private readonly Project4Context _context;

        public ManagerReportServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vManagerReport>> getManagerReports()
        {
            var result = _context.vManagerReports.ToList();
            return result;
        }
    }
}
