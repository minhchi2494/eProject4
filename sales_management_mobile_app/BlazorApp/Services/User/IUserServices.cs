using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IUserServices
    {
        Task<List<User>> getUsers(User searchUser);
        Task<User> getUser(string id);
        Task<bool> checkLogin(string username, string password);
        Task<bool> createUser(MultipartFormDataContent newUser);
        Task<bool> updateUser(User editUser);
    }
}
