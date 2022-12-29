using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IDirectorServices
    {
        Task<List<Director>> getDirectors(Director searchDirector);
        Task<Director> getDirector(string id);
        //Task<Director> checkLogin(string username, string password);
        Task<bool> createDirector(MultipartFormDataContent newDirector);
        Task<bool> updateDirector(Director editDirector);
        //Task<bool> createKpiValue(string dirId, int kpiValue);
    }
}
