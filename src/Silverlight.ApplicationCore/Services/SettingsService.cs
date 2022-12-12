using Silverlight.ApplicationCore.Dtos;
using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.ApplicationCore.Specifications;

namespace Silverlight.ApplicationCore.Services
{
    public class SettingsService: ISettingsService
    {
        private readonly IRepository<Settings> _settingsRepository;

        public SettingsService(IRepository<Settings> settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<SettingsDto> GetAllValueAsync()
        {
            return new SettingsDto()
            {
                WebsiteName = await GetValueByKeyAsync(Constants.Constants.Settings.WEBSITE_NAME),
                Logo = await GetValueByKeyAsync(Constants.Constants.Settings.LOGO),
                LogoShort = await GetValueByKeyAsync(Constants.Constants.Settings.LOGO_SHORT),
                Phone = await GetValueByKeyAsync(Constants.Constants.Settings.PHONE),
                Address = await GetValueByKeyAsync(Constants.Constants.Settings.ADDRESS),
                Facebook = await GetValueByKeyAsync(Constants.Constants.Settings.FACEBOOK),
                Instagram = await GetValueByKeyAsync(Constants.Constants.Settings.INSTAGRAM),
                Twitter = await GetValueByKeyAsync(Constants.Constants.Settings.TWITTER)
            };
        }

        public async Task<string> GetValueByKeyAsync(string key)
        {
            var spec = new SettingsByKeySpec(key);
            var data = await _settingsRepository.FirstOrDefaultAsync(spec);
            if (data != null)
            {
                return data.Value ?? string.Empty;
            }
            return string.Empty;
        }

        public async Task CreateAsync(Settings input)
        {
            await _settingsRepository.AddAsync(input);
        }

        public async Task<bool> UpdateAllAsync(SettingsDto input)
        {
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.WEBSITE_NAME, Value = input.WebsiteName });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.LOGO, Value = input.Logo });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.LOGO_SHORT, Value = input.LogoShort });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.PHONE, Value = input.Phone });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.ADDRESS, Value = input.Address });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.FACEBOOK, Value = input.Facebook });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.INSTAGRAM, Value = input.Instagram });
            await UpdateAsync(new Settings() { Key = Constants.Constants.Settings.TWITTER, Value = input.Twitter });

            return true;
        }

        public async Task UpdateAsync(Settings input)
        {
            await _settingsRepository.UpdateAsync(input);
        }
    }
}
