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
        Task<Admin> checkLogin(string username, string password);
        //Task<Admin> checkLogin(Admin admin);
        Task<bool> createAdmin(Admin newAdmin);
        Task<bool> updateAdmin(Admin editAdmin);
    }
}
