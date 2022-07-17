using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
namespace WebAPI.Services
{
    public interface IManagerServices
    {
        Task<List<Manager>> getManagers(Manager searchManager);
        Task<Manager> getManager(string id);
        Task<Manager> checkLogin(string username, string password);
        Task<bool> createManager(Manager newManager);
        Task<bool> updateManager(string id, string oldPass, string Pass);
    }
}
