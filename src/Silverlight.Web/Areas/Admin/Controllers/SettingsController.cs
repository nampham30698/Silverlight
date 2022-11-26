using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Constants;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.ApplicationCore.Utilities;
using Silverlight.Web.Areas.Admin.ViewModels;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class SettingsController : ControllerBase
    {
        private readonly IAppLogger<SettingsController> _appLogger;
        private readonly ISettingsService _settingsService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SettingsController(IAppLogger<SettingsController> appLogger,
                                  ISettingsService settingsService,
                                  IMapper mapper,
                                  IWebHostEnvironment webHostEnvironment)
        {
            _appLogger = appLogger;
            _settingsService = settingsService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _settingsService.GetAllValueAsync();
            var vm = _mapper.Map<SettingsViewModel>(data);
            return View(vm);
        }

        public async Task<bool> Save(SettingsViewModel vm)
        {
            if (vm.IsLogoChange)
            {
                vm.Logo = Utility.CreateFile(_webHostEnvironment, vm.LogoFormFile, "images/logo");
            }
            if (vm.IsLogoShortChange)
            {
                vm.LogoShort = Utility.CreateFile(_webHostEnvironment, vm.LogoShortFormFile, "images/logo");
            }

            return await _settingsService.UpdateAllAsync(vm);
        }
    }
}
