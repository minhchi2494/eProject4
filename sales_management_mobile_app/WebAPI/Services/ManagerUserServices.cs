using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class ManagerUserServices : IManagerUserServices
    {
        private readonly Project4Context _context;

        public ManagerUserServices(Project4Context context)
        {
            _context = context;
        }

        //public async Task<List<vManagerUser>> getManagerUsers(vManagerUser managerUser)
        //{
        //    var result = _context.vManagerUser.Where(x => x.Id.Equals(managerUser.Id)).ToList();
        //    return result;
        //}

        public async Task<List<vManagerUser>> getManagerUsers(string id)
        {
            var result = _context.vManagerUser.Where(x => x.Id.Equals(id)).ToList();
            return result;
        }
    }
}
