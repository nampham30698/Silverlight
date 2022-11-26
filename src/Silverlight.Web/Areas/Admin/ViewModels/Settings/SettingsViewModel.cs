using Silverlight.ApplicationCore.Dtos;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class SettingsViewModel : SettingsDto
    {
        public bool IsLogoChange { get; set; }
        public bool IsLogoShortChange { get; set; }
        public IFormFile LogoFormFile { get; set; }
        public IFormFile LogoShortFormFile { get; set; }
    }
}
