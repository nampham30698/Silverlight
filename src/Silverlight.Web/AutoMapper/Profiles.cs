using AutoMapper;
using Silverlight.ApplicationCore.Dtos;
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
        }
    }
}
