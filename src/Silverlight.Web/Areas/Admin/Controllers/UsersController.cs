using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Dtos.User;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.Web.Areas.Admin.ViewModels;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAppLogger<UsersController> _appLogger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IAppLogger<UsersController> appLogger,
                                  IUserService userService,
                                  IMapper mapper)
        {
            _appLogger = appLogger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = new IndexUserViewModel();
            try
            {
                var users = await _userService.GetAllAsync(new UserFilterDto() { Take = 10 });

                return View(vm);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return View(vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexUserViewModel vm)
        {
            try
            {
                var filter = new UserFilterDto()
                {
                    Skip = vm.Skip,
                    Take = vm.Take,
                    TextSearch = vm.TextSearch
                };

                var users = await _userService.GetAllAsync(filter);

                vm.Users = users;

                return View(vm);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            var user = await _userService.GetByIdAsync(id);

            var vm = _mapper.Map<UserViewModel>(user);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(UserViewModel vm)
        {
            try
            {
                if (string.IsNullOrEmpty(vm.Id))
                {
                    await _userService.CreateAsync(vm);
                }
                else
                {
                    await _userService.UpdateAsync(vm);
                }
                return RedirectToAction(nameof(this.Index));
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return View(vm);
            }
        }
    }
}
