using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.Contracts;
using Store.Domain.Repositories;
using Store.Services.Contracts.Category;
using Store.Services.Framework;
using Store.Services.Mapping;

namespace Store.Services
{
    public interface ICategoryService : IService
    {
        Task<CategoryDto> AddAsync(int userId, CategoryDto dto);
        Task<CategoryDto> DeleteAsync(int userId, int id);
        Task<CategoryDto> GetAsync(int userId, int id);
        Task<IList<CategoryDto>> GetAsync(int userId, PagingOptions pagingOptions);
        Task<CategoryDto> UpdateAsync(int userId, CategoryDto dto);
    }

    public class CategoryService : Service, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> AddAsync(int userId, CategoryDto dto)
        {
            var model = CategoryMapper.Map(dto);
            var newModel = await _categoryRepository.AddAsync(userId, model);
            var result = CategoryDtoMapper.Map(newModel);

            return result;

        }

        public async Task<CategoryDto> DeleteAsync(int userId, int id)
        {
            var model = await _categoryRepository.DeleteAsync(userId, id);
            var result = CategoryDtoMapper.Map(model);

            return result;
        }

        public async Task<CategoryDto> GetAsync(int userId, int id)
        {
            var model = await _categoryRepository.GetAsync(userId, id);
            var result = CategoryDtoMapper.Map(model);

            return result;
        }

        public async Task<IList<CategoryDto>> GetAsync(int userId, PagingOptions pagingOptions)
        {
            var models = await _categoryRepository.GetAsync(userId, null, pagingOptions);
            var results = CategoryDtoMapper.Map(models);

            return results;
        }

        public async Task<CategoryDto> UpdateAsync(int userId, CategoryDto dto)
        {
            var model = await _categoryRepository.GetAsync(userId, dto.Id);
            if (model == null)
            {
                return null;
            }

            CategoryMapper.Map(dto, model);
            await _categoryRepository.SaveChangesAsync(userId);

            // Return a fresh copy of the saved object.
            return await GetAsync(userId, model.Id);
        }
    }
}
