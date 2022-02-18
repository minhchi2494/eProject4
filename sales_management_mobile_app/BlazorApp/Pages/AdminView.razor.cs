//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using BlazorApp.Services;
//using BlazorApp.Models;
//using Microsoft.AspNetCore.Components;
//namespace BlazorApp.Pages
//{
//    public partial class AdminView
//    {
//        [Inject]
//        private IAdminServices _services { get; set; }

//        private List<Admin> admin;

//        protected override async Task OnInitializedAsync()
//        {
//            admin = await _services.getAdmins();
//        }
//    }
//}
