using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class DirectorReportServices
    {
        private readonly Project4Context _context;

        public DirectorReportServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vDirectorReport>> getDirectorReports()
        {
            var result = _context.vDirectorReports.ToList();
            return result;
        }
    }
}
