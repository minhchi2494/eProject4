using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Services;
using Blazored.Toast;
using BlazorApp.Services.AdminModel;
using BlazorApp.Helpers;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredToast();

            builder.Services
                .AddScoped<IAlertService, AlertService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped<IAdminServices, AdminServices>();

            builder.Services.AddScoped<IStoreServices, StoreServices>();

            builder.Services.AddScoped<ILocationServices, LocationServices>();

            builder.Services.AddScoped<IManagerServices, ManagerServices>();

            builder.Services.AddScoped<IRoleServices, RoleServices>();

            builder.Services.AddScoped<ITargetServices, TargetServices>();

            builder.Services.AddScoped<ISalesDetailServices, SalesDetailServices>();

            builder.Services.AddScoped<IStoreSalesDetailServices, StoreSalesDetailServices>();

            builder.Services.AddScoped<IUserServices, UserServices>();

            builder.Services.AddScoped<IProductServices, ProductServices>();

            builder.Services.AddScoped<ISalesDetailTargetUser, SalesDetailTargetUserServices>();

            builder.Services.AddScoped<IManagerUserServices, ManagerUserServices>();

            builder.Services.AddScoped<ITargetUserManagerServices, TargetUserManagerServices>();

            builder.Services.AddScoped<IStoreUserServices, StoreUserServices>();

            builder.Services.AddAuthorizationCore();


            // configure http client
            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);

                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var accountService = host.Services.GetRequiredService<IAdminServices>();
            await accountService.Initialize();


            

            await host.RunAsync();
        }
    }
}
