using Microsoft.AspNetCore.Mvc.Rendering;
using Silverlight.Web.Dtos;

namespace Silverlight.Web.Areas.Admin.ViewModels
{
    public class CategoryIndexViewModel
    {
        public string TextSearch { get; set; }

        public int CategoryType { get; set; }
        public string TreeViewDataHtml { get; set; }

        public List<DropDownListItem> CategoryTypeDDL { get; set; }
    }
}
