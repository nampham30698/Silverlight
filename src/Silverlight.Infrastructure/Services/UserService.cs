using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Silverlight.ApplicationCore.Dtos.User;
using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UserService> _appLogger;

        public UserService(UserManager<ApplicationUser> userManager,
                           IMapper mapper,
                           IAppLogger<UserService> appLogger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appLogger = appLogger;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(UserFilterDto filter)
        {
            try
            {
                var users = await _userManager.Users.Where(x => string.IsNullOrEmpty(filter.TextSearch) ||
                x.FirstName.ToLower().Contains(filter.TextSearch) ||
                x.LastName.ToLower().Contains(filter.TextSearch) ||
                x.Email.ToLower().Contains(filter.TextSearch) ||
                x.PhoneNumber.ToLower().Contains(filter.TextSearch)).Skip(filter.Skip).Take(filter.Take).ToListAsync();

                var data = _mapper.Map<List<UserDto>>(users);

                return data;
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return new List<UserDto>();
            }
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var users = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<UserDto>(users);
        }

        public async Task CreateAsync(UserDto userDto)
        {
            try
            {
                var user = new ApplicationUser()
                {
                    UserName = userDto.UserName,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber,
                    Address = userDto.Address,
                    UrlImage = userDto.UrlImage,
                };

                await _userManager.CreateAsync(user);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
            }
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userDto.Id);
                if (user != null)
                {
                    user.UserName = userDto.UserName;
                    user.FirstName = userDto.FirstName;
                    user.LastName = userDto.LastName;
                    user.Email = userDto.Email;
                    user.PhoneNumber = userDto.PhoneNumber;
                    user.Address = userDto.Address;
                    user.UrlImage = userDto.UrlImage;

                    await _userManager.UpdateAsync(user);
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
            }
        }
    }
}
