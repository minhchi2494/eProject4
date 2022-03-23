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
            //var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).Include(x => x.User).
            //            SingleOrDefault(x => x.Id.Equals(id));
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).SingleOrDefault(x => x.Id.Equals(id));
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
        public async Task<bool> createActualQuantity(StoreSalesDetail ssd)
        {
            //StoreSalesDetail result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).SingleOrDefault(x => x.StoreId.Equals(ssd.StoreId));
            //if (result == null)
            //{
                StoreSalesDetail result = new StoreSalesDetail()
                {
                    ProductId = ssd.ProductId,
                    Date = ssd.Date,
                    StoreId = ssd.StoreId,
                    StoreActualQuantity = ssd.StoreActualQuantity,
                    Product = _context.Products.SingleOrDefault(p=>p.Id == ssd.ProductId),
                    Store = _context.Stores.SingleOrDefault(s=>s.Id == ssd.StoreId)
                };
                _context.StoreSalesDetails.Add(result);
                _context.SaveChanges();
            //}

            //var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).First(x => x.StoreId.Equals(storeId));
            string productId = result.ProductId;

            //var acc = _context.SalesDetails.Where(x => x.UserId.Equals(ssd.UserId)).ToList();
            int userId = result.Store.UserId;
            var user = _context.Users.SingleOrDefault(x => x.Id.Equals(userId));
            int targetId = user.TargetId;

            var acc = _context.SalesDetails.Where(x => x.UserId.Equals(userId)).ToList();
            //var temp = acc.Where(x => x.ProductId.Equals(ssd.ProductId)).ToList();
            var temp = acc.Where(x => x.ProductId.Equals(productId)).ToList();

            int quant = 0;
            //foreach (var item in temp)
            //{

            //    quant += item.SalesActualQuantity;
            //}



            SalesDetail bien = new SalesDetail();
            //if (result != null)
            //{
            //    _context.StoreSalesDetails.Add(ssd);
            //    _context.SaveChanges();

                if (temp.Count() != 0)
                {
                    var date = temp.SingleOrDefault(x => x.Date.Equals(ssd.Date));
                    if (date != null)
                    {
                        quant += date.SalesActualQuantity;
                        date.SalesActualQuantity = ssd.StoreActualQuantity + quant;
                        //date.TargetId = date.TargetId;
                        //date.UserId = userId;
                        //date.Date = ssd.Date;
                        //date.ProductId = ssd.ProductId;
                        _context.SaveChanges();
                    }
                    else
                    {
                        bien.SalesActualQuantity = ssd.StoreActualQuantity;
                        bien.TargetId = targetId;
                        bien.UserId = userId;
                        bien.Date = ssd.Date;
                        bien.ProductId = ssd.ProductId;
                        _context.SalesDetails.Add(bien);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    bien.SalesActualQuantity = ssd.StoreActualQuantity;
                    bien.TargetId = targetId;
                    bien.UserId = userId;
                    bien.Date = ssd.Date;
                    bien.ProductId = ssd.ProductId;
                    _context.SalesDetails.Add(bien);
                    _context.SaveChanges();
                }
                return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public async Task<List<StoreSalesDetail>> getStoreSalesDetails(DateTime? fromDate, DateTime? toDate)
        {
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store)
                                              .Where(x => x.Date >= fromDate).Where(x => x.Date <= toDate).ToList();
                return result;
            }
        }


        public async Task<bool> createStoreSalesDetail(StoreSalesDetail ssd)
        {
            var result = _context.StoreSalesDetails.Include(x => x.Product).Include(x => x.Store).SingleOrDefault(x => x.Id == ssd.Id);
            if (result == null)
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
    }
}
