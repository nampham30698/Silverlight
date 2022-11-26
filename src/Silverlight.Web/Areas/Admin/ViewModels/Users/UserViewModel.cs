using Silverlight.ApplicationCore.Dtos;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class UserViewModel : UserDto
    {
        public IFormFile UrlImageFormFile { get; set; }
    }
}
