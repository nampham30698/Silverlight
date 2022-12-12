using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Services
{
    public class Blog_CategoryService : IBlog_Category
    {
        private readonly IRepository<Blog_Category> _blogCategoryRepository;
        private readonly IAppLogger<Blog_CategoryService> _appLogger;

        public Blog_CategoryService(IRepository<Blog_Category> categoryRepository, IAppLogger<Blog_CategoryService> appLogger)
        {
            _blogCategoryRepository = categoryRepository;
            _appLogger = appLogger;
        }

        public async Task<List<Blog_Category>> GetAllAsync()
        {
            return await _blogCategoryRepository.ListAsync();
        }

        public async Task CreateAsync(Blog_Category data)
        {
            await _blogCategoryRepository.AddAsync(data);
        }

        public async Task UpdateAsync(Blog_Category data)
        {
            await _blogCategoryRepository.UpdateAsync(data);
        }

        public async Task DeleteAsync(Blog_Category data)
        {
            await _blogCategoryRepository.DeleteAsync(data);
        }
    }
}
