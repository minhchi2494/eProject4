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

            var acc = _context.SalesDetails.SingleOrDefault(x => x.UserId.Equals(ssd.UserId));
            var temp = _context.SalesDetails.Where(x=>x.ProductId.Equals(ssd.ProductId));
            //SalesDetail acc = new SalesDetail();
            if (result != null)
            {
                _context.StoreSalesDetails.Add(ssd);
                
                if ((acc.Date == ssd.Date || acc.Date == null) && (acc.ProductId != ssd.ProductId || acc.ProductId == null) )
                {
                    acc.TargetId = acc.TargetId;
                    acc.UserId = ssd.UserId;
                    acc.Date = ssd.Date;
                    acc.ProductId = ssd.ProductId;
                    acc.SalesActualQuantity = ssd.StoreActualQuantity; 
                }
                acc.SalesActualQuantity = ssd.StoreActualQuantity + Convert.ToInt32(temp);

                _context.SalesDetails.Add(acc);
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

        public Task<SalesDetailServices> create()
        {
            throw new NotImplementedException();
        }
    }
}
