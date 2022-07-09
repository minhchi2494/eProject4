using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly Project4Context _context;
        public UserServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<User>> getUsers(User searchUser)
        {
            var result = _context.Users.Include(x => x.Manager).Where(x => x.IsActive == true).ToList();

            if (!string.IsNullOrEmpty(searchUser.Fullname))
            {
                result = result.Where(x => x.Fullname.ToLower().Contains(searchUser.Fullname.ToLower())).ToList();
            }
            return result;
        }


        public async Task<User> getUser(int id)
        {
            var result = _context.Users.Include(x => x.Manager).Where(x => x.IsActive == true).SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> checkLogin(string username, string password)
        {
            var model = _context.Users.Include(x => x.Manager).Where(x => x.IsActive == true).SingleOrDefault(a => a.Username.Equals(username));
            if (model != null)
            {
                string pass = PinCodeSecurity.pinDecrypt(model.Password);
                if (password.Equals(pass))
                {
                    return model;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> createUser(User newUser)
        {
            var model = _context.Users.Include(x => x.Manager).SingleOrDefault(x => x.Id.Equals(newUser.Id));
            if (model == null)
            {
                newUser.Password = PinCodeSecurity.pinEncrypt(newUser.Password);

                var manager = _context.Managers.Include(x => x.Users).SingleOrDefault(x => x.Id.Equals(newUser.ManagerId));
                //var director = _context.Directors.Include(x => x.Managers).SingleOrDefault(x => x.Id.Equals(manager.DirectorId));

                var currentUsers = _context.Users.Include(x => x.Stores).Where(x => x.ManagerId == manager.Id).ToList();
                int countCurrentUsers = currentUsers.Where(x => x.ManagerId == manager.Id).Count();
                decimal kpiEachUser = manager.KpiValue / (countCurrentUsers +1);
                for (int i = 0; i < countCurrentUsers; i++)
                {
                    currentUsers[i].KpiValue = kpiEachUser;
                }

                newUser.KpiValue = kpiEachUser; 
                _context.Users.Add(newUser);
                //_context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateUser(User editUser)
        {
            var model = _context.Users.Include(x => x.Manager).Where(x => x.IsActive == true).SingleOrDefault(x=>x.Id.Equals(editUser.Id));
            if (model != null)
            {
                model.Username = editUser.Username;
                model.Password = PinCodeSecurity.pinEncrypt(editUser.Password);
                model.Fullname = editUser.Fullname;
                model.Email = editUser.Email;
                model.Phone = editUser.Phone;
                model.Address = editUser.Address;
                model.KpiValue = editUser.KpiValue;
                model.ManagerId = editUser.ManagerId;
                Manager manager = _context.Managers.SingleOrDefault(x => x.Id.Equals(editUser.ManagerId));
                model.Manager = manager;

                model.IsActive = editUser.IsActive;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public async Task<bool> setActualKPI(int userId)
        {
            List<Store> storeBelongUserId = null;
            List<Store> storeList = _context.Stores.ToList();
            //get list storeId belong userId
            foreach(Store st in storeList)
            {
                if(st.UserId == userId)
                {
                    storeBelongUserId.Add(st);
                }
            }
            List<Order> orderListBelongUserId = null;
            List<Order> orderList = _context.Orders.ToList();
            //get list Order belong storeId which user owner
            foreach(Order o in orderList)
            {
                foreach(Store sbt in storeBelongUserId)
                {
                    if(sbt.Id == o.StoreId)
                    {
                        orderListBelongUserId.Add(o);
                    }
                }
            }
            
            double sumOfOrderValue = 0;
            // sum Order value 
            foreach(Order od in orderListBelongUserId)
            {
                sumOfOrderValue += (double) od.TotalPrice;
            }
            User u = await getUser(userId);
            float actualKPI = (float) (sumOfOrderValue / u.KpiValue) * 100;
            DateTime moment = new DateTime();
            int lastMonth = moment.Month - 1;
            if (moment.Day == 1 && u.ActualKpi > 0)
            {
                KpiPerMonth kpm = new KpiPerMonth(lastMonth, actualKPI, userId);// save last month KPI
                u.ActualKpi = 0.0f;//reset ActualKpi for current Month
                _context.SaveChanges();
            }
            u.ActualKpi = actualKPI;
            _context.SaveChanges();
            return true;
        }*/

       
    }
}
