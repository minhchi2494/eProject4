using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IUserServices
    {
        Task<List<User>> getUsers(User searchUser);
        Task<User> getUser(string id);
        Task<bool> checkLogin(string username, string password);
        Task<bool> createUser(User newUser);
        Task<bool> updateUser(User editUser);
    }
}
