using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IAdminServices
    {
        //Task<Admin> checkLogin(string username, string password);
        //Task<Admin> checkLogin(Admin admin);
        //Task<List<Admin>> getAdmins();
        //Task<Admin> getAdmin(int id);
        //Task<bool> createAdmin(Admin newAdmin);
        //Task<bool> updateAdmin(Admin editAdmin);

        Admin Authenticate(string username, string password);
        IEnumerable<Admin> GetAll();
        Admin getAdmin(int id);
        Admin Create(Admin admin, string password);
        void Update(Admin admin, string password = null);
        void Delete(int id);
    }
}
