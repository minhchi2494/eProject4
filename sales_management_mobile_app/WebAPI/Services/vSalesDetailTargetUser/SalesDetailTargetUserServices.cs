using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class SalesDetailTargetUserServices : ISalesDetailTargetUser
    {
        private readonly Project4Context _context;

        public SalesDetailTargetUserServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vSalesDetailTargetUser>> getSalesDetailTargetUsers(DateTime? fromDate, DateTime? toDate)
        {
            var stu = _context.vSalesDetailTargetUser.ToList();
            if (fromDate == null && toDate == null)
            {
                return stu;
            }
            else
            {
                stu = _context.vSalesDetailTargetUser.Where(x => x.Date >= fromDate).Where(x => x.Date <= toDate).ToList();
                return stu;
            }
        }

        
    }
}
