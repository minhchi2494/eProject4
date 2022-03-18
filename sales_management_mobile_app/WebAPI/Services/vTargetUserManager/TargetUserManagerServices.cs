using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class TargetUserManagerServices : ITargetUserManagerServices
    {
        private readonly Project4Context _context;

        public TargetUserManagerServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vTargetUserManager>> getTargetUserManagers(DateTime? fromDate, DateTime? toDate)
        {
            var tum = _context.vTargetUserManager.ToList();
            if (fromDate == null && toDate == null)
            {
                return tum;
            }
            else
            {
                tum = _context.vTargetUserManager.Where(x => x.CreatedOn >= fromDate).Where(x => x.CreatedOn <= toDate).ToList();
                return tum;
            }
        }
    }
}
