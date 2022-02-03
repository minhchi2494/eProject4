using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly Project4Context _context;

        public RoleServices(Project4Context context)
        {
            _context = context;
        }

        public async Task<List<Role>> getRoles(Role searchRole)
        {
            var result = _context.Roles.ToList();
            result = result.Where(x => x.IsDelete == false).ToList();
            if (!string.IsNullOrEmpty(searchRole.Title))
            {
                result = result.Where(x => x.Title.ToLower().Contains(searchRole.Title.ToLower())).ToList();
            }
            return result;
        }

        public async Task<bool> createRole(Role newRole)
        {
            var role = _context.Roles.SingleOrDefault(r => r.Id.Equals(newRole.Id));
            if (role == null)
            {
                _context.Roles.Add(newRole);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> updateRole(Role editRole)
        {
            var role = _context.Roles.SingleOrDefault(r => r.Id.Equals(editRole.Id));
            if (role != null)
            {
                role.Title = editRole.Title;
                role.IsDelete = editRole.IsDelete;
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
