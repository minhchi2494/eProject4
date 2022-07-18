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

        public async Task<bool> saveOrder(string userId, string storeId, List<CartItem> orderList)
        {
            double totalPrice = 0;
            int quantity = 0;

            foreach (CartItem tt in orderList)//sum of quantity and Price in CartItem
            {
                totalPrice += tt.Quantity * tt.Price;
                quantity += tt.Quantity;
            }
            Order newOrder = new Order() {//create Order
                ActualQuantity = quantity,
                StoreId = storeId,
                TotalPrice = (decimal)totalPrice,
                CreatedOn = DateTime.Now
            };
            _context.Add(newOrder);
            _context.SaveChanges();

            foreach(CartItem ci in orderList){// create OrderDetails
                OrderDetail od = new OrderDetail(ci.ProductId, newOrder.Id, ci.Price * ci.Quantity, ci.Quantity);
                _context.Add(od);
                _context.SaveChanges();
            }

            await this.setActualKPI(userId);//get ActualQuantity in Order to set ActualKpi for Sale person 
            return true;
        }

        public async Task<bool> setActualKPI(string userId)
        {
            List<Store> storeBelongUserId = new List<Store>();
            List<Store> storeList = _context.Stores.ToList();
            
            foreach (Store st in storeList)//get list storeId belong userId
            {
                if (st.UserId == userId)
                {
                    storeBelongUserId.Add(st);
                }
            }

            List<Order> orderListBelongUserId = new List<Order>();
            List<Order> orderList = _context.Orders.ToList();
            //***********************************//
            DateTime moment = DateTime.Now;
            
            foreach (Order o in orderList)
            {
                if (o.CreatedOn.Month == moment.Month)//only order list in current month
                {
                    foreach (Store sbt in storeBelongUserId)//get list Order belong storeId owner userId
                    {
                        if (sbt.Id == o.StoreId)
                        {
                            orderListBelongUserId.Add(o);
                        }
                    }
                }
            }

            int sumofQuantityInOrder = 0;
            
            foreach (Order od in orderListBelongUserId)// sum of quantity in Order from above list
            {
                sumofQuantityInOrder += od.ActualQuantity;
            }
            User u = _context.Users.SingleOrDefault(u=>u.Id.Equals(userId));

            //if (moment.Day == 1 && u.ActualKpi > 0)
            if (u.ActualKpi >= 0)
            {
                int lastMonth = moment.Month - 1;
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, sumofQuantityInOrder, u.Username);// save last month KPI
                u.ActualKpi = 0;//reset ActualKpi on last month to save value of current month
                _context.KpiPerMonths.Add(kpm);
                _context.SaveChanges();
            }
            u.ActualKpi = sumofQuantityInOrder;
            _context.SaveChanges();

            await this.getActualKpiFromSalePerson(u.ManagerId);// calculate ActualKpi for manager from sale person

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

            int totalActualKpiOfSalePersons = 0;
            foreach(User u in listUserOfManager)//get actualKpi of Sale person owner manager
            {
                totalActualKpiOfSalePersons += u.ActualKpi;
            }

            Manager mgr = _context.Managers.SingleOrDefault(m => m.Id.Equals(managerId));

            DateTime moment = DateTime.Now;

            if (mgr.ActualKpi >= 0)
            {
                int lastMonth = moment.Month - 1;
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, totalActualKpiOfSalePersons, mgr.Username);// save last month KPI
                mgr.ActualKpi = 0;//reset ActualKpi on last month to save value of current month
                _context.KpiPerMonths.Add(kpm);
                _context.SaveChanges();
            }
            mgr.ActualKpi = totalActualKpiOfSalePersons;
            _context.SaveChanges();

            this.getActualKpiFromManager(mgr.DirectorId);

            return Task.FromResult("Calculate success!!!!");
        }

        public Task<string> getActualKpiFromManager(string dirId)
        {
            List<Manager> listManagerOfDir = new List<Manager>();
            List<Manager> listManager = _context.Managers.ToList();

            foreach (Manager u in listManager)//get manager list owner dirId
            {
                if (u.DirectorId == dirId)
                {
                    listManagerOfDir.Add(u);
                }
            }

            int totalActualKpiOfManager = 0;

            foreach (Manager u in listManagerOfDir)//sum of ActualKpi from manager list above
            {
                totalActualKpiOfManager += u.ActualKpi;
            }
            Director dir = _context.Directors.SingleOrDefault(m => m.Id.Equals(dirId));

            DateTime moment = DateTime.Now;

            if (dir.ActualKpi >= 0)
            {
                int lastMonth = moment.Month - 1;
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, totalActualKpiOfManager, dir.Username);// save last month KPI
                dir.ActualKpi = 0;//reset ActualKpi on last month to save value of current month
                _context.KpiPerMonths.Add(kpm);
                _context.SaveChanges();
            }
            dir.ActualKpi = totalActualKpiOfManager;
            _context.SaveChanges();

            return Task.FromResult("Calculate success!!!!");
        }
    }
}
