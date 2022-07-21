using Amazon.S3;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "da85i8t2o";
        public const string API_KEY = "782372915787355";
        public const string API_SECRET = "6peu85e37dcz83v7zrm8IsX3d5k";

        public static void Main(string[] args)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);

            //var builder = CreateHostBuilder(args).Build().Run();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            //builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
            //builder.Services.AddAWSService<IAmazonS3>();
            //var app = builder.Build();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                  
                });
    }
}
