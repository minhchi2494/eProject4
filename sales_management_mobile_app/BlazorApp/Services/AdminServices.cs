using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;
using System.Net.Http;
using BlazorApp.Models.AdminModel;
using BlazorApp.Services.AdminModel;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Services
{
    public class AdminServices : IAdminServices
    {
       // public HttpClient _httpClient;
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "admin";

        public Admin Admin { get; private set; }

        public AdminServices(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

       

        public async Task Delete(int id)
        {
            await _httpService.Delete($"/admin/{id}");

            // auto logout if the logged in user deleted their own record
            if (id == Admin.Id)
            {
                await Logout();
            }
        }

        public async Task<IList<Admin>> GetAll()
        {
            return await _httpService.Get<IList<Admin>>("/admin");
        }

        public async Task<Admin> GetById(int id)
        {
            return await _httpService.Get<Admin>($"/admin/{id}");
        }

        public async Task Initialize()
        {
            Admin = await _localStorageService.GetItem<Admin>(_userKey);
        }

        public async Task Login(Login model)
        {
            Admin = await _httpService.Post<Admin>("/admin/authenticate", model);
            await _localStorageService.SetItem(_userKey, Admin);
        }

        public async Task Logout()
        {
            Admin = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("admin/login");
        }

        public async Task Register(AddAdmin model)
        {
            await _httpService.Post("/admin/register", model);
        }

        public async Task Update(int id, EditAdmin model)
        {
            await _httpService.Put($"/admin/{id}", model);

            // update stored user if the logged in user updated their own record
            if (id == Admin.Id)
            {
                // update local storage
                Admin.Fullname = model.Fullname;
                Admin.Phone = model.Phone;
                Admin.Username = model.Username;
                await _localStorageService.SetItem(_userKey, Admin);
            }
        }

        //public async Task<bool> checkLogin(string username, string password)
        //{
        //    var result = await _httpClient.PostAsJsonAsync($"/api/Admin?Username={username}/Password={password}", username);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public async Task<List<Admin>> getAdmins()
        //{
        //    var result = await _httpClient.GetFromJsonAsync<List<Admin>>($"/api/Admin");
        //    return result;
        //}

        //public async Task<Admin> getAdmin(int id)
        //{
        //    var result = await _httpClient.GetFromJsonAsync<Admin>($"/api/Admin/{id}");
        //    return result;
        //}

        //public Task<bool> createAdmin(Admin newAdmin)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> updateAdmin(Admin editAdmin)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
