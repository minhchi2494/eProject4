using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

using WebAPI.Models;

namespace WebAPI.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly Project4Context _context;

        public AdminServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<Admin> checkLogin(string username, string password)
        {
            var model = _context.Admins.SingleOrDefault(a => a.Username.Equals(username));
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

        //public async Task<Admin> checkLogin(Admin admin)
        //{
        //    var model = _context.Admins.SingleOrDefault(a => a.Username.Equals(admin.Username));
        //    if (model != null)
        //    {
        //        string pass = PinCodeSecurity.pinDecrypt(model.Password);
        //        if (admin.Password.Equals(pass))
        //        {
        //            return model;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<bool> createAdmin(Admin newAdmin)
        {
            var model = _context.Admins.SingleOrDefault(x=>x.Id.Equals(newAdmin.Id));
            if (model == null)
            {
                newAdmin.Password = PinCodeSecurity.pinEncrypt(newAdmin.Password);
                _context.Admins.Add(newAdmin);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateAdmin(Admin editAdmin)
        {
            var model = _context.Admins.SingleOrDefault(x=>x.Id.Equals(editAdmin.Id));
            if (model != null)
            {
                model.Username = editAdmin.Username;
                model.Password = PinCodeSecurity.pinEncrypt(editAdmin.Password);
                model.Fullname = editAdmin.Fullname;
                model.Email = editAdmin.Email;
                model.Phone = editAdmin.Phone;
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
