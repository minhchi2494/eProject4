using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Admin, AdminModel>();
            CreateMap<RegisterModel, Admin>();
            CreateMap<UpdateModel, Admin>();
   
        }
    }
}
