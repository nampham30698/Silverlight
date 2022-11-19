using Silverlight.ApplicationCore.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync(UserFilterDto filter);
        Task<UserDto> GetByIdAsync(string id);
        Task CreateAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);
    }
}
