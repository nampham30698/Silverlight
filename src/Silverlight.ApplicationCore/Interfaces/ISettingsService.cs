using Silverlight.ApplicationCore.Dtos;
using Silverlight.ApplicationCore.Entities;

namespace Silverlight.ApplicationCore.Interfaces
{
    public interface ISettingsService
    {
        Task<SettingsDto> GetAllValueAsync();
        Task<string> GetValueByKeyAsync(string key);
        Task CreateAsync(Settings input);
        Task<bool> UpdateAllAsync(SettingsDto input);
        Task UpdateAsync(Settings input);
    }
}
