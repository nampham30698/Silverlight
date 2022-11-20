using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Constants;
using Silverlight.ApplicationCore.Interfaces;
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
        public SettingsController(IAppLogger<SettingsController> appLogger,
                                  ISettingsService settingsService,
                                  IMapper mapper)
        {
            _appLogger = appLogger;
            _settingsService = settingsService;
            _mapper = mapper;   
        }

        public async Task<IActionResult> Index()
        {
            var data = await _settingsService.GetAllValueAsync();
            var vm = _mapper.Map<SettingsViewModel>(data);
            return View(vm);
        }

        public async Task<bool> Save(SettingsViewModel vm)
        {
            return await _settingsService.UpdateAllAsync(vm);
        }
    }
}
