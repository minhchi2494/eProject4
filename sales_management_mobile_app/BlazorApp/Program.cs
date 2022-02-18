using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using BlazorApp.Services;


namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<IAdminServices, AdminServices>();

            builder.Services.AddScoped<IStoreServices, StoreServices>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:54350") });

            await builder.Build().RunAsync();
        }
    }
}
