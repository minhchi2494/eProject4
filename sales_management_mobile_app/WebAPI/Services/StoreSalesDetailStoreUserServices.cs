using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class StoreSalesDetailStoreUserServices : IStoreSalesDetailStoreUserServices
    {
        private readonly Project4Context _context;

        public StoreSalesDetailStoreUserServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vStoreSalesDetailStoreUser>> getStoreSalesDetailStoreUsers(DateTime? fromDate, DateTime? toDate)
        {
            var ssu = _context.vStoreSalesDetailStoreUser.ToList();
            if (fromDate == null && toDate == null)
            {
                return ssu;
            }
            else
            {
                ssu = _context.vStoreSalesDetailStoreUser.Where(x => x.Date >= fromDate).Where(x => x.Date <= toDate).ToList();
                return ssu;
            }
        }
    }
}
