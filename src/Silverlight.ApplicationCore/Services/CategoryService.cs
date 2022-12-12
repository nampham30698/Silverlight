using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Silverlight.ApplicationCore.Dtos;
using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Enums;
using Silverlight.ApplicationCore.Interfaces;
using Silverlight.ApplicationCore.Specifications;
using System.Linq;
using System.Text;

namespace Silverlight.ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IAppLogger<CategoryService> _appLogger;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository,
                               IAppLogger<CategoryService> appLogger,
                               IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _appLogger = appLogger;
            _mapper = mapper;
        }

        public async Task<string> GetAllForTreeViewAsync(int? categoryType = null)
        {
            var categories = await GetRecursionCategory(categoryType);

            var sb = new StringBuilder();

            sb.Append("<ul class='jstree-container-ul jstree-children'>");

            foreach (var category in categories)
            {
                sb.Append(SetCategoryToHtmlString(category));
            }

            sb.Append("</ul>");

            return sb.ToString();
        }

        public async Task<List<CategoryDto>> GetRecursionCategory(int? categoryType = null)
        {
            try
            {
                var spec = new CategoryLv1Spec(categoryType);

                var result = await _categoryRepository.ListAsync(spec);

                var resultDto = _mapper.Map<List<CategoryDto>>(result);

                foreach (var category in resultDto)
                {
                    category.Children = await GetChildrenCategory(category.Id);
                }

                return resultDto;
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
                return default;
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                return _mapper.Map<CategoryDto>(category);
            }

            return new CategoryDto();
        }

        public async Task CreateAsync(CategoryDto category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(CategoryDto category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        private async Task<List<CategoryDto>> GetChildrenCategory(int parentId)
        {
            var spec = new CategoryByParentSpec(parentId);

            var result = await _categoryRepository.ListAsync(spec);

            var resultDto = _mapper.Map<List<CategoryDto>>(result);

            if (resultDto.Count == 0)
            {
                return resultDto;
            }

            foreach (var category in resultDto)
            {
                category.Children = await GetChildrenCategory(category.Id);
            }

            return resultDto;
        }

        private string SetCategoryToHtmlString(CategoryDto item)
        {
            var sb = new StringBuilder();

            sb.Append($"<li id='{item.Id}' class='jstree-node'>{item.Name}");

            if (item.Children.Count > 0)
            {
                sb.Append("<ul>");

                foreach (var child in item.Children)
                {
                    SetCategoryToHtmlString(child);
                }

                sb.Append("</ul>");
            }

            sb.Append("</li>");

            return sb.ToString();
        }
    }
}
