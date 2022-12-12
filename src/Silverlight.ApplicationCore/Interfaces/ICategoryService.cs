using Silverlight.ApplicationCore.Dtos;
using Silverlight.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Interfaces
{
    public interface ICategoryService
    {
        Task<string> GetAllForTreeViewAsync(int? categoryType = null);
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryDto category);
        Task UpdateAsync(CategoryDto category);
        Task DeleteAsync(int id);
    }
}
