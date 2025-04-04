﻿using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Interfaces;
using System.Linq;

namespace Silverlight.ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
        }
    }
}
