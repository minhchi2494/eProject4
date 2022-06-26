using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerServices : IManagerServices
    {
        private readonly Project4Context _context;

        public ManagerServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Manager>> getManagers(Manager searchManager)
        {
            var result = _context.Managers.Include(a => a.Location).Include(a => a.Target).ToList();
            if (!string.IsNullOrEmpty(searchManager.Fullname))
            {
                result = result.Where(x => x.Fullname.ToLower().Contains(searchManager.Fullname.ToLower())).ToList();
            }
            return result;
        }

        public async Task<Manager> getManager(string id)
        {
            var result = _context.Managers.Include(a => a.Location).Include(a => a.Target).SingleOrDefault(x => x.Id.Equals(id));  
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> createManager(Manager newManager)
        {
            var manager = _context.Managers.Include(a => a.Location).SingleOrDefault(m => m.Id.Equals(newManager.Id));
            if (manager == null)
            {
                _context.Managers.Add(newManager);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateManager(Manager editManager)
        {
            var manager = _context.Managers.Include(a => a.Location).SingleOrDefault(m => m.Id.Equals(editManager.Id));
            if (manager != null)
            {
                manager.Fullname = editManager.Fullname;
                manager.StaffQuantity = editManager.StaffQuantity;

                manager.LocationId = editManager.LocationId;
                Location loc = _context.Locations.SingleOrDefault(l => l.Id == editManager.LocationId);
                manager.Location = loc;

                manager.TargetId = editManager.TargetId;
                Target targ = _context.Targets.SingleOrDefault(t => t.Id == editManager.TargetId);
                manager.Target = targ;

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
