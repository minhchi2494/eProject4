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
        //    StoreSalesDetail result = new StoreSalesDetail()
        //    {
        //        ProductId = ssd.ProductId,
        //        Date = ssd.Date,
        //        StoreId = ssd.StoreId,
        //        StoreActualQuantity = ssd.StoreActualQuantity,
        //        Product = _context.Products.SingleOrDefault(p => p.Id == ssd.ProductId),
        //        Store = _context.Stores.SingleOrDefault(s => s.Id == ssd.StoreId)
        //    };
        //    _context.StoreSalesDetails.Add(result);
        //    _context.SaveChanges();



        //    string productId = result.ProductId;


        //    int userId = result.Store.UserId;
        //    var user = _context.Users.SingleOrDefault(x => x.Id.Equals(userId));


        //    var targetList = _context.Targets.Where(x => x.UserId.Equals(userId)).ToList();
        //    var target = targetList.First();
        //    int targetId = target.Id;

        //    //var acc = _context.SalesDetails.Where(x => x.UserId.Equals(userId)).ToList();
        //    var acc = _context.SalesDetails.Where(x => x.TargetId.Equals(targetId)).ToList();
        //    var temp = acc.Where(x => x.ProductId.Equals(productId)).ToList();


        //    int quant = 0;

        //    SalesDetail bien = new SalesDetail();

        //    if (temp.Count() != 0)
        //    {
        //        var date = temp.SingleOrDefault(x => x.Date.Equals(ssd.Date));
        //        if (date != null)
        //        {
        //            quant += date.SalesActualQuantity;
        //            date.SalesActualQuantity = ssd.StoreActualQuantity + quant;
        //            _context.SaveChanges();
        //        }
        //        else
        //        {
        //            bien.SalesActualQuantity = ssd.StoreActualQuantity;
        //            bien.TargetId = targetId;
        //            bien.Date = ssd.Date;
        //            bien.ProductId = ssd.ProductId;
        //            _context.SalesDetails.Add(bien);
        //            _context.SaveChanges();
        //        }

        //    }
        //    else
        //    {
        //        bien.SalesActualQuantity = ssd.StoreActualQuantity;
        //        bien.TargetId = targetId;
        //        bien.Date = ssd.Date;
        //        bien.ProductId = ssd.ProductId;
        //        _context.SalesDetails.Add(bien);
        //        _context.SaveChanges();
        //    }


        //    //tính cộng dồn cho bảng Targets
        //    //load lại số record theo target id bên bảng SalesDetail
        //    var acc2 = _context.SalesDetails.Where(x => x.TargetId.Equals(targetId)).ToList();
        //    //tìm lại trong bảng Target record mà Date nhập vào trong StoreSalesDetail nằm trong khoảng From Date To Date bên bảng Target
        //    var target2 = targetList.SingleOrDefault(x => x.FromDate <= ssd.Date && x.ToDate >= ssd.Date);
        //    //tìm danh sách record trong bảng SalesDetail mà có Date nằm trong khoảng FromDate ToDate đã tìm dc trong đối tượng target2
        //    var listSDByDate = acc2.Where(x => x.Date >= target2.FromDate && x.Date <= target2.ToDate).ToList();
        //    if (listSDByDate != null)
        //    {
        //        int total = 0;
        //        foreach (var item in listSDByDate)
        //        {
        //            total += item.SalesActualQuantity;
        //        }
        //        target2.ActualQuantity = total;
        //        _context.SaveChanges();
        //    }
            return true;
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
