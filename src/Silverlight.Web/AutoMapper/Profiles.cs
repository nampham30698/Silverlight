using AutoMapper;
using Silverlight.ApplicationCore.Dtos;
using Silverlight.ApplicationCore.Entities;
using Silverlight.Infrastructure.Identity;
using Silverlight.Web.Areas.Admin.ViewModels;

namespace Silverlight.Web.AutoMapper
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<ApplicationUser,UserDto>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<SettingsDto, SettingsViewModel>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, CategoryViewModel>();
        }
    }
}
