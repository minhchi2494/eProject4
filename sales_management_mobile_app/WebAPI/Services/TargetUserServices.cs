using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class TargetUserServices : ITargetUserServices
    {
        private readonly Project4Context _context;

        public TargetUserServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vTargetUser>> getTargetUsers(DateTime? fromDate, DateTime? toDate)
        {
            var tu = _context.vTargetUser.ToList();
            if (fromDate == null && toDate == null)
            {
                return tu;
            }
            else
            {
                tu = _context.vTargetUser.Where(x => x.CreatedOn >= fromDate).Where(x => x.CreatedOn <= toDate).ToList();
                return tu;
            }
        }
    }
}
