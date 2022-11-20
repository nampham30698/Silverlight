using Silverlight.ApplicationCore.Dtos;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class IndexUserViewModel
    {
        public string? TextSearch { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public PaginationPageViewModel Paper { get; set; }
        public IEnumerable<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
