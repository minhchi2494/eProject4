using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class StoreSalesDetailServices : IStoreSalesDetailServices
    {
        private readonly Project4Context _context;

        public StoreSalesDetailServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<StoreSalesDetail> getStoreSalesDetail(int id)
        {
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).
                        SingleOrDefault(x=>x.Id.Equals(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        //create actual quantity base store id
        public async Task<bool> createActualQuantity(string storeId, StoreSalesDetail ssd)
        {
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).
                        First(x => x.StoreId.Equals(storeId));
            if (result != null)
            {
                _context.StoreSalesDetails.Add(ssd);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<StoreSalesDetail>> getStoreSalesDetails(DateTime? fromDate, DateTime? toDate)
        {
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store)
                                              .Where(x => x.Date >= fromDate).Where(x => x.Date <= toDate).ToList();
                return result;
            }
        }
    }
}
