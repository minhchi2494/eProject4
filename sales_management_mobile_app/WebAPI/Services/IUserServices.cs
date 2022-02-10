using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserServices
    {
        Task<List<User>> getUsers(User sesrchUser);
    }
}
