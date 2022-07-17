using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerServices : IManagerServices
    {
        private readonly Project4Context _context;

        public ManagerServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<Manager> checkLogin(string username, string password)
        {
            var mng = _context.Managers.Include(x => x.Role).Include(x => x.Director).SingleOrDefault(a => a.Username.Equals(username));
            if (mng != null)
            {
                string pass = PinCodeSecurity.pinDecrypt(mng.Password);
                if (password.Equals(pass))
                {
                    return mng;
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

        public async Task<List<Manager>> getManagers(Manager searchManager)
        {
            var result = _context.Managers.Include(x => x.Role).Include(a => a.Director).ToList();
            if (!string.IsNullOrEmpty(searchManager.Fullname))
            {
                result = result.Where(x => x.Fullname.ToLower().Contains(searchManager.Fullname.ToLower())).ToList();
            }
            return result;
        }

        public async Task<Manager> getManager(string id)
        {
            var result = _context.Managers.Include(x => x.Role).Include(a => a.Director).SingleOrDefault(x => x.Id.Equals(id));  
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> createManager(Manager newManager)
        {
            var manager = _context.Managers.Include(x => x.Role).Include(a => a.Director).SingleOrDefault(m => m.Id.Equals(newManager.Id));
            if (manager == null)
            {
                newManager.Password = PinCodeSecurity.pinEncrypt(newManager.Password);
                

                var managers = _context.Managers.Include(x => x.Role).Include(x => x.Director).Where(x => x.DirectorId == newManager.DirectorId).ToList();
                int countManagers = managers.Where(x => x.DirectorId == newManager.DirectorId).Count();
                var director = _context.Directors.Include(x => x.Role).SingleOrDefault(x => x.Id == newManager.DirectorId);
                double kpiEachManager = (director.KpiValue*1.0) / (countManagers+1*1.0);
                int a = (int)(Math.Ceiling(kpiEachManager));
                for (int i = 0; i < countManagers; i++)
                {
                    managers[i].KpiValue = a;


                    var userss = _context.Users.Include(x => x.Role).Include(x => x.Manager).Where(x => x.ManagerId == managers[i].Id).ToList();
                    int countUser = userss.Where(x => x.ManagerId == managers[i].Id).Count();
                    if (countUser != 0)
                    {
                        double kpiEachUser = (kpiEachManager*1.0) / (countUser*1.0);
                        int b = (int)(Math.Ceiling(kpiEachUser));
                        for (int j = 0; j < countUser; j++)
                        {
                            userss[j].KpiValue = b;
                        }
                    }

                }

                newManager.KpiValue = a;
                _context.Managers.Add(newManager);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateManager(string id, string oldPass, string Pass)
        {
            var manager = _context.Managers.Include(x => x.Role).Include(a => a.Director).SingleOrDefault(m => m.Id.Equals(id));
            if (manager != null)
            {
                var oldPassword = PinCodeSecurity.pinEncrypt(oldPass);
                var password = PinCodeSecurity.pinEncrypt(Pass);
                if (oldPassword.Equals(manager.Password))
                {
                    manager.Password = password;
                    _context.SaveChanges();
                     return true;
                    //manager.Username = editManager.Username;
                    //manager.Password = PinCodeSecurity.pinEncrypt(editManager.Password);
                    //manager.Fullname = editManager.Fullname;
                    //manager.Email = editManager.Email;
                    //manager.Phone = editManager.Phone;
                    //manager.Address = editManager.Address;
                    //manager.KpiValue = editManager.KpiValue;
                    //manager.DirectorId = editManager.DirectorId;
                    //Director dir = _context.Directors.SingleOrDefault(d => d.Id == editManager.DirectorId);
                    //manager.Director = dir;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
    }
}
