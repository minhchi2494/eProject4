using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;
using BlazorApp.Models.AdminModel;

namespace BlazorApp.Services
{
    public interface IAdminServices
    {
        //Task<bool> checkLogin(string username, string password);
        //Task<List<Admin>> getAdmins();
        //Task<Admin> getAdmin(int id);
        //Task<bool> createAdmin(Admin newAdmin);
        //Task<bool> updateAdmin(Admin editAdmin);


        Admin Admin { get; }


        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task Register(AddAdmin model);
        Task<IList<Admin>> GetAll();
        Task<Admin> GetById(int id);
        Task Update(int id, EditAdmin model);
        Task Delete(int id);
    }
}
