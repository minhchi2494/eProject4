using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly Project4Context _context;

        public OrderServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Order>> getOrders(DateTime? fromDate, DateTime? toDate)
        {
            var result = _context.Orders.Include(x => x.Store).ToList();
            if (fromDate == null && toDate == null)
            {
                return result;
            }
            else
            {
                result = _context.Orders.Include(x => x.Store).Where(x => x.CreatedOn >= fromDate).Where(x => x.CreatedOn <= toDate).ToList();
                return result;
            }
        }

        public async Task<Order> getOrder(int id)
        {
            var result = _context.Orders.Include(x => x.Store).SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> saveOrder(string storeId, List<CartItem> orderList)
        {
            double totalPrice = 0;
            int quantity = 0;
            foreach (CartItem tt in orderList)
            {
                totalPrice += tt.Quantity * tt.Price;
                quantity += tt.Quantity;
            }
            Order newOrder = new Order() {
                ActualQuantity = quantity,
                StoreId = storeId,
                TotalPrice = (decimal)totalPrice,
                CreatedOn = DateTime.Now
            };
            _context.Add(newOrder);
            _context.SaveChanges();
            foreach(CartItem ci in orderList){
                OrderDetail od = new OrderDetail(ci.ProductId, newOrder.Id, ci.Price * ci.Quantity, DateTime.Now, ci.Quantity);
                _context.Add(od);
                _context.SaveChanges();
            }
            return true;
        }
    }
}
