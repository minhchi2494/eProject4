using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class DirectorManager : IDirectorManager
    {
        private readonly Project4Context _context;

        public DirectorManager(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<vDirectorManager>> getDirectorManagers(string id)
        {
            var result = _context.vDirectorManager.Where(x => x.Id.Equals(id)).ToList();
            return result;
        }
    }
}
