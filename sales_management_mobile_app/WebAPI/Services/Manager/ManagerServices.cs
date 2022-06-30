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
            var mng = _context.Managers.SingleOrDefault(a => a.Username.Equals(username));
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
            var result = _context.Managers.Include(a => a.Director).ToList();
            if (!string.IsNullOrEmpty(searchManager.Fullname))
            {
                result = result.Where(x => x.Fullname.ToLower().Contains(searchManager.Fullname.ToLower())).ToList();
            }
            return result;
        }

        public async Task<Manager> getManager(string id)
        {
            var result = _context.Managers.Include(a => a.Director).SingleOrDefault(x => x.Id.Equals(id));  
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
            var manager = _context.Managers.Include(a => a.Director).SingleOrDefault(m => m.Id.Equals(newManager.Id));
            if (manager == null)
            {
                newManager.Password = PinCodeSecurity.pinEncrypt(newManager.Password);
                _context.Managers.Add(newManager);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateManager(Manager editManager)
        {
            var manager = _context.Managers.Include(a => a.Director).SingleOrDefault(m => m.Id.Equals(editManager.Id));
            if (manager != null)
            {
                manager.Username = editManager.Username;
                manager.Password = PinCodeSecurity.pinEncrypt(editManager.Password);
                manager.Fullname = editManager.Fullname;
                manager.Email = editManager.Email;
                manager.Phone = editManager.Phone;
                manager.Address = editManager.Address;
                manager.KpiYear = editManager.KpiYear;
                manager.KpiValue = editManager.KpiValue;
                manager.StaffQuantity = editManager.StaffQuantity;

                manager.DirectorId = editManager.DirectorId;
                Director dir = _context.Directors.SingleOrDefault(d => d.Id == editManager.DirectorId);
                manager.Director = dir;

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
