using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Dtos;
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
        public async Task<IActionResult> Index(int page = 1, string search = "")
        {
            var vm = new IndexUserViewModel();
            try
            {
                var users = await _userService.GetAllAsync(new UserFilterDto() { Take = 10});
                var totalCount = await _userService.GetTotalCountAsync(new UserFilterDto());

                vm.Users = users;
                vm.Paper = new PaginationPageViewModel(totalCount, page);
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

                var totalCount = await _userService.GetTotalCountAsync(filter);

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
        [Route("admin/users/create-or-edit/{id}")]
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);

                var vm = _mapper.Map<UserViewModel>(user);

                return View(vm);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
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
