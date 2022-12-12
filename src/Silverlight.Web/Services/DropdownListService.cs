using Silverlight.ApplicationCore.Enums;
using Silverlight.ApplicationCore.Extensions;
using Silverlight.Web.Dtos;
using System;

namespace Silverlight.Web.Services
{
    public interface IDropdownListService
    {
        List<DropDownListItem> GetCategoryTypeDDL();
    }

    public class DropdownListService : IDropdownListService
    {
        public DropdownListService()
        {

        }

        public List<DropDownListItem> GetCategoryTypeDDL()
        {
            var result = new List<DropDownListItem>();

            foreach (var item in Enum.GetValues(typeof(CategoryType)))
            {
                result.Add(new DropDownListItem()
                {
                    Text = EnumExtensions.GetDescription((CategoryType)(int)item),
                    Value = ((int)item).ToString()
                });
            }

            return result;
        }
    }
}
