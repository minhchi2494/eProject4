using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class KpiPerMonthServices
    {
        private readonly Project4Context _context;

        public KpiPerMonthServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<KpiPerMonth>> getKpiPerMonths(string username)
        {
            var result = _context.KpiPerMonths.Where(x => x.UserName.Equals(username)).ToList();
            return result;
        }
    }
}
