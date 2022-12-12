using Silverlight.ApplicationCore.Entities;
using Silverlight.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silverlight.ApplicationCore.Services
{
    public class Blog_TagService : IBlog_Tag
    {
        private readonly IRepository<Blog_Tag> _blogTagRepository;
        private readonly IAppLogger<Blog_TagService> _appLogger;

        public Blog_TagService(IRepository<Blog_Tag> categoryRepository, IAppLogger<Blog_TagService> appLogger)
        {
            _blogTagRepository = categoryRepository;
            _appLogger = appLogger;
        }

        public async Task<List<Blog_Tag>> GetAllAsync()
        {
            return await _blogTagRepository.ListAsync();
        }

        public async Task CreateAsync(Blog_Tag data)
        {
            await _blogTagRepository.AddAsync(data);
        }

        public async Task UpdateAsync(Blog_Tag data)
        {
            await _blogTagRepository.UpdateAsync(data);
        }

        public async Task DeleteAsync(Blog_Tag data)
        {
            await _blogTagRepository.DeleteAsync(data);
        }
    }
}
