using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IStoreServices
    {
        Task<List<Store>> getStores(Store searchStore);
        Task<List<Store>> getList();
        Task<Store> getStore(string id);
        Task<bool> createStore(Store newStore);
        Task<bool> updateStore(Store editStore);
    }
}
