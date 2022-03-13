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
        Task<List<User>> getUsers(User searchUser);
        Task<User> getUser(int id);
        Task<User> checkLogin(string username, string password);
        Task<bool> createUser(User newUser);
        Task<bool> updateUser(User editUser);

    }
}
