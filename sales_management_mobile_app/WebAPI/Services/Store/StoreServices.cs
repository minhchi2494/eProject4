﻿using Microsoft.EntityFrameworkCore;
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
            var result = _context.Stores.Include(a => a.Users).Where(x => x.IsActive == true).ToList();
            if (!string.IsNullOrEmpty(searchStore.Name))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchStore.Name.ToLower())).ToList();
            }
            return result;
        }

        public async Task<Store> getStore(string id)
        {
            var result = _context.Stores.Include(a => a.Users).SingleOrDefault(x => x.Id.Equals(id));
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
            var store = _context.Stores.Include(a => a.Users).SingleOrDefault(x=>x.Id.Equals(newStore.Id));
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
            var store = _context.Stores.Include(a => a.Users).SingleOrDefault(x=>x.Id.Equals(editStore.Id));
            if (store != null)
            {
                store.Name = editStore.Name;
                store.Email = editStore.Email;
                store.Phone = editStore.Phone;
                store.Address = editStore.Address;
                //store.Longitude = editStore.Longitude;
                //store.Latitude = editStore.Latitude;

                store.UserId = editStore.UserId;
                User user = _context.Users.SingleOrDefault(u => u.Id.Equals(editStore.UserId));
                store.Users = user;

                store.IsActive = editStore.IsActive;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Store>> getList()
        {
            List<Store> storeList = _context.Stores.ToList();
            return storeList;
        }
    }
}
