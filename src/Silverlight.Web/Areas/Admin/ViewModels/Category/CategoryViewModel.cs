using Silverlight.ApplicationCore.Dtos;
using Silverlight.Web.Dtos;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class CategoryViewModel : CategoryDto
    {
        public List<DropDownListItem> CategoryTypeDDL { get; set; }
    }
}
