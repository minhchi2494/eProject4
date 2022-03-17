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
            //var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).
            //            SingleOrDefault(x=>x.Id.Equals(id));
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).Include(x => x.User).
                        SingleOrDefault(x => x.Id.Equals(id));
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
            //var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).
            //            First(x => x.StoreId.Equals(storeId));
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).Include(x => x.User).
                        First(x => x.StoreId.Equals(storeId));
            //check daily sale
            var acc = _context.SalesDetails.Where(x => x.UserId.Equals(ssd.UserId)).ToList();
            var temp = acc.Where(x => x.ProductId.Equals(ssd.ProductId)).ToList();

            //check target
            var salestarget = _context.Targets.Where(x => x.Id.Equals(ssd.User.TargetId));


            int quant = 0;
            foreach (var item in temp)
            {

                quant += item.SalesActualQuantity;
            }

            var date = temp.SingleOrDefault(x => x.Date.Equals(ssd.Date));

            SalesDetail bien = new SalesDetail();
            if (result != null)
            {
                _context.StoreSalesDetails.Add(ssd);
                _context.SaveChanges();

                if (temp.Count() != 0)
                {
                    if (date != null)
                    {
                        date.SalesActualQuantity = ssd.StoreActualQuantity + quant;
                        date.TargetId = date.TargetId;
                        date.UserId = ssd.UserId;
                        date.Date = ssd.Date;
                        date.ProductId = ssd.ProductId;
                        _context.SaveChanges();
                    }
                    else
                    {
                        bien.SalesActualQuantity = ssd.StoreActualQuantity;
                        bien.TargetId = ssd.User.TargetId;
                        bien.UserId = ssd.UserId;
                        bien.Date = ssd.Date;
                        bien.ProductId = ssd.ProductId;
                        _context.SaveChanges();
                    }

                }
                else
                {
                    bien.SalesActualQuantity = ssd.StoreActualQuantity;
                    bien.TargetId = ssd.User.TargetId;
                    bien.UserId = ssd.UserId;
                    bien.Date = ssd.Date;
                    bien.ProductId = ssd.ProductId;
                    _context.SalesDetails.Add(bien);
                    _context.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<StoreSalesDetail>> getStoreSalesDetails(DateTime? fromDate, DateTime? toDate)
        {
            //var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store).ToList();
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).Include(x => x.User).ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                //result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.SalesDetail).Include(x => x.Store)
                result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).Include(x => x.User)
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
