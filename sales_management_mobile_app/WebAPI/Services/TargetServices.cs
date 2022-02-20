using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class TargetServices : ITargetServices
    {
        private readonly Project4Context _context;

        public TargetServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Target>> getTargets(Target searchTarget, DateTime? fromDate, DateTime? toDate)
        {
            var targets = _context.Targets.ToList();
            if (fromDate == null && toDate == null)
            {
                return targets;
            }
            else
            {
                targets = _context.Targets.Where(x => x.CreatedOn >= fromDate).Where(x => x.CreatedOn <= toDate).ToList();
                return targets;
            }

        }
    }
}
