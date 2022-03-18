using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly Project4Context _context;

        public PerformanceService(Project4Context context)
        {
            _context = context;
        }



        public List<Performance> getAll()
        {
            var result = _context.Performances.Include(a => a.User).ToList();

            return result;
        }



    }
}
