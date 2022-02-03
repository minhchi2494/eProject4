using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerServices : IManagerServices
    {
        //private readonly AppDbContext _context;

        //public ManagerServices(AppDbContext context)
        //{
        //    _context = context;
        //}

        //public async Task<List<manager>> getManagers(manager searchManager)
        //{
        //    var result = _context.managers
        //        //.Include(a => a.loc)
        //        .ToList();
        //    if (!string.IsNullOrEmpty(searchManager.fullname))
        //    {
        //        result = result.Where(x => x.fullname.ToLower().Contains(searchManager.fullname.ToLower())).ToList();
        //    }
        //    return result;
        //}

        //public async Task<bool> createManager(manager newManager)
        //{
        //    var manager = _context.managers.SingleOrDefault(m => m.id.Equals(newManager.id));
        //    if (manager == null)
        //    {
        //        _context.managers.Add(newManager);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> updateManager(manager editManager)
        //{
        //    var manager = _context.managers.SingleOrDefault(m => m.id.Equals(editManager.id));
        //    if (manager != null)
        //    {
        //        manager.fullname = editManager.fullname;
        //        manager.staffquantity = editManager.staffquantity;
        //        Location loc = _context.locations.SingleOrDefault(l=>l.id == editManager.loc.id);
        //        manager.loc = loc;  
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
