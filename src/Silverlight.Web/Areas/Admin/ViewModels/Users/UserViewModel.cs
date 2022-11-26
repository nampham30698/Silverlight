using Silverlight.ApplicationCore.Dtos;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class UserViewModel : UserDto
    {
        public bool IsUrlImageChange { get; set; }
        public IFormFile UrlImageFormFile { get; set; }
    }
}
