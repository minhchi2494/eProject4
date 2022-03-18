using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IRoleServices
    {
        Task<List<Role>> getRoles(Role searchRole);
        Task<Role> getRole(int id);
        Task<bool> createRole(Role newRole);
        Task<bool> updateRole(Role editRole);
    }
}
