using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Models;
namespace BlazorApp.Services
{
    public interface IManagerServices
    {
        Task<List<Manager>> getManagers(Manager searchManager);
        Task<Manager> getManager(string id);
        Task<bool> createManager(MultipartFormDataContent newManager);
        Task<bool> updateManager(Manager editManager);
    }
}
