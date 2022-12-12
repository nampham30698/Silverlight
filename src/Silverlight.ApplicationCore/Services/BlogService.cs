using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Services
{
    public class BlogService: IBlogService
    {
        private readonly IRepository<Blog> _blogRepository;
        private readonly IAppLogger<BlogService> _appLogger;

        public BlogService(IRepository<Blog> categoryRepository, IAppLogger<BlogService> appLogger)
        {
            _blogRepository = categoryRepository;
            _appLogger = appLogger;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.ListAsync();
        }

        public async Task CreateAsync(Blog data)
        {
            await _blogRepository.AddAsync(data);
        }

        public async Task UpdateAsync(Blog data)
        {
            await _blogRepository.UpdateAsync(data);
        }

        public async Task DeleteAsync(Blog data)
        {
            await _blogRepository.DeleteAsync(data);
        }
    }
}
