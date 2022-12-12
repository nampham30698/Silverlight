using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Enums;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.ApplicationCore.Services;
using Silverlight.Web.Areas.Admin.ViewModels;
using Silverlight.Web.Controllers;
using Silverlight.Web.Services;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IAppLogger<CategoryController> _appLogger;
        private readonly ICategoryService _categoryService;
        private readonly IDropdownListService _dropdownListService;
        private readonly IMapper _mapper;
        public CategoryController(IAppLogger<CategoryController> appLogger,
                                  ICategoryService categoryService,
                                  IDropdownListService dropdownListService,
                                  IMapper mapper)
        {
            _appLogger = appLogger;
            _categoryService = categoryService;
            _dropdownListService = dropdownListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var a = UserId;
            var vm = new CategoryIndexViewModel();
            try
            {
                InitControlIndex(vm);
                vm.CategoryType = int.Parse(vm.CategoryTypeDDL.First().Value);
                vm.TreeViewDataHtml = await _categoryService.GetAllForTreeViewAsync(vm.CategoryType);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CategoryIndexViewModel vm)
        {
            try
            {
                InitControlIndex(vm);
                vm.TreeViewDataHtml = await _categoryService.GetAllForTreeViewAsync(vm.CategoryType);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);

                var vm = _mapper.Map<CategoryViewModel>(category);
                vm.IsActive = true;

                InitControlCreateOrEdit(vm);
                return View(vm);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(CategoryViewModel vm)
        {
            try
            {
                if (vm.Id > 0)
                {
                    vm.CreatorUserId = UserId;
                    await _categoryService.CreateAsync(vm);
                }
                else
                {
                    await _categoryService.UpdateAsync(vm);
                }

                InitControlCreateOrEdit(vm);
                return RedirectToAction(nameof(this.Index));
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return View(vm);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
            }

            return RedirectToAction(nameof(this.Index));
        }

        private void InitControlIndex(CategoryIndexViewModel vm)
        {
            vm.CategoryTypeDDL = _dropdownListService.GetCategoryTypeDDL();
        }

        private void InitControlCreateOrEdit(CategoryViewModel vm)
        {
            vm.CategoryTypeDDL = _dropdownListService.GetCategoryTypeDDL();
        }
    }
}
