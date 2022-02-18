using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IAdminServices
    {
        Task<Admin> checkLogin(string username, string password);
        Task<List<Admin>> getAdmins();
        Task<Admin> getAdmin(int id);
        Task<bool> createAdmin(Admin newAdmin);
        Task<bool> updateAdmin(Admin editAdmin);
    }
}
