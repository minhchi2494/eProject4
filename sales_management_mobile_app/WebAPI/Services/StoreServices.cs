using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class StoreServices : IStoreServices
    {
        private readonly Project4Context _context;

        public StoreServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Store>> getStores(Store searchStore)
        {
            //var result = _context.Stores.Include(a=>a.Location).ToList();
            //result = result.Where(x => x.IsDelete == false).ToList();
            var result = _context.Stores.Include(a => a.Location).Where(x => x.IsActive == true).ToList();
            if (!string.IsNullOrEmpty(searchStore.Name))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchStore.Name.ToLower())).ToList();
            }
            return result;
        }

        public async Task<Store> getStore(string id)
        {
            var result = _context.Stores.Include(a=>a.Location).SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> createStore(Store newStore)
        {
            var store = _context.Stores.Include(a=>a.Location).SingleOrDefault(x=>x.Id.Equals(newStore.Id));
            if (store == null)
            {
                _context.Stores.Add(newStore);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateStore(Store editStore)
        {
            var store = _context.Stores.Include(a => a.Location).SingleOrDefault(x=>x.Id.Equals(editStore.Id));
            if (store != null)
            {
                store.Name = editStore.Name;
                store.Email = editStore.Email;
                store.Phone = editStore.Phone;
                store.Address = editStore.Address;
                //store.Longitude = editStore.Longitude;
                //store.Latitude = editStore.Latitude;
                store.LocationId = editStore.LocationId;
                Location loc = _context.Locations.SingleOrDefault(l => l.Id.Equals(editStore.LocationId));
                store.Location = loc;
                store.IsActive = editStore.IsActive;
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
