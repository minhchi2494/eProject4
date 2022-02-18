using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IStoreServices
    {
        Task<List<Store>> getStores(Store searchStore);
        Task<Store> getStore(string id);
        Task<bool> createStore(Store newStore);
        Task<bool> updateStore(Store editStore);
    }
}
