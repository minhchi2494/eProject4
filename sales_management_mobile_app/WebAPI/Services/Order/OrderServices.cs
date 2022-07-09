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

        public async Task<bool> saveOrder(int userId, string storeId, List<CartItem> orderList)
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
                OrderDetail od = new OrderDetail(ci.ProductId, newOrder.Id, ci.Price * ci.Quantity, ci.Quantity);
                _context.Add(od);
                _context.SaveChanges();
            }
            Console.WriteLine(newOrder.TotalPrice);
            await setActualKPI(userId);
            return true;
        }

        public async Task<bool> setActualKPI(int userId)
        {
            List<Store> storeBelongUserId = new List<Store>();
            List<Store> storeList = _context.Stores.ToList();
            //get list storeId belong userId
            foreach (Store st in storeList)
            {
                if (st.UserId == userId)
                {
                    storeBelongUserId.Add(st);
                }
            }
            Console.WriteLine(storeBelongUserId.Count);
            List<Order> orderListBelongUserId = new List<Order>();
            DateTime moment = DateTime.Now;
            
            List<Order> orderList = _context.Orders.ToList();
            Console.WriteLine("current Month" + moment.Month);
            //get list Order belong storeId owner user
            foreach (Order o in orderList)
            {
                if (o.CreatedOn.Month == moment.Month)
                {
                    foreach (Store sbt in storeBelongUserId)
                    {
                        if (sbt.Id == o.StoreId)
                        {
                            orderListBelongUserId.Add(o);
                        }
                    }
                }
            }
            Console.WriteLine(orderListBelongUserId.Count);
            decimal sumOfOrderValue = 0;
            // sum Order value 
            foreach (Order od in orderListBelongUserId)
            {
                sumOfOrderValue += od.TotalPrice;
            }
            User u = _context.Users.SingleOrDefault(u=>u.Id.Equals(userId));

            if (moment.Day == 1 && u.ActualKpi > 0)
            {
                int lastMonth = moment.Month - 1;
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, sumOfOrderValue, userId);// save last month KPI
                u.ActualKpi = 0;//reset ActualKpi for current Month
                _context.SaveChanges();
            }
            u.ActualKpi = sumOfOrderValue;
            _context.SaveChanges();
            Console.WriteLine(u.ActualKpi);
            await getActualKpiFromSalePerson(u.ManagerId);
            return true;
        }

        public Task<string> getActualKpiFromSalePerson(string managerId)
        {
            List<User> listUserOfManager = new List<User>();
            List<User> listUser = _context.Users.ToList();
            foreach(User u in listUser)//get list sale person owner manager
            {
                if(u.ManagerId == managerId)
                {
                    listUserOfManager.Add(u);
                }
            }
            decimal totalActualKpiOfSalePerson = 0;
            foreach(User u in listUserOfManager)//get actualKpi of Saleperson owner manager
            {
                totalActualKpiOfSalePerson += u.ActualKpi;
            }
            Console.WriteLine(totalActualKpiOfSalePerson);
            Manager mgr = _context.Managers.SingleOrDefault(m => m.Id.Equals(managerId));
            Console.WriteLine(mgr.Id);
            DateTime moment = DateTime.Now;
            
            if (moment.Day == 1 && mgr.ActualKpi > 0)
            {
                int lastMonth = moment.Month - 1;
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, totalActualKpiOfSalePerson, Int32.Parse(managerId));// save last month KPI
                mgr.ActualKpi = 0;//reset ActualKpi for current Month
                _context.SaveChanges();
            }
            mgr.ActualKpi = totalActualKpiOfSalePerson;
            _context.SaveChanges();
            Console.WriteLine(mgr.ActualKpi);
            getActualKpiFromManager(mgr.DirectorId);
            return Task.FromResult("Calculate success!!!!");
        }

        public Task<string> getActualKpiFromManager(string dirId)
        {
            List<Manager> listManagerOfDir = new List<Manager>();
            List<Manager> listManager = _context.Managers.ToList();
            foreach (Manager u in listManager)
            {
                if (u.DirectorId == dirId)
                {
                    listManagerOfDir.Add(u);
                }
            }
            decimal totalActualKpiOfManager = 0;
            foreach (Manager u in listManagerOfDir)
            {
                totalActualKpiOfManager += u.ActualKpi;
            }
            Director dir = _context.Directors.SingleOrDefault(m => m.Id.Equals(dirId));
            DateTime moment = new DateTime();
            
            if (moment.Day == 1 && dir.ActualKpi > 0)
            {
                int lastMonth = moment.Month - 1;
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, totalActualKpiOfManager, Int32.Parse(dirId));// save last month KPI
                dir.ActualKpi = 0;//reset ActualKpi for current Month
                _context.SaveChanges();
            }
            dir.ActualKpi = totalActualKpiOfManager;
            _context.SaveChanges();
            return Task.FromResult("Calculate success!!!!");
        }
    }
}
