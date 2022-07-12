using Microsoft.EntityFrameworkCore;
using System;
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

                var manager = _context.Managers.Include(x => x.Director).SingleOrDefault(x => x.Id.Equals(newUser.ManagerId));
                //var director = _context.Directors.Include(x => x.Managers).SingleOrDefault(x => x.Id.Equals(manager.DirectorId));

                var currentUsers = _context.Users.Include(x => x.Manager).Where(x => x.ManagerId == manager.Id).ToList();
                int countCurrentUsers = currentUsers.Where(x => x.ManagerId == manager.Id).Count();
                int kpiEachUser = manager.KpiValue / (countCurrentUsers +1);
                for (int i = 0; i < countCurrentUsers; i++)
                {
                    currentUsers[i].KpiValue = kpiEachUser;
                }

                newUser.KpiValue = kpiEachUser; 
                _context.Users.Add(newUser);
                _context.SaveChanges();
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
    }
}
