using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IManagerUserServices
    {
        //Task<List<vManagerUser>> getManagerUsers(vManagerUser managerUser);
        Task<List<vManagerUser>> getManagerUsers(string id);
    }
}
