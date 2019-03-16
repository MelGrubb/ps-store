using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.Contracts;
using Store.Domain.Repositories;
using Store.Services.Contracts.Product;
using Store.Services.Framework;
using Store.Services.Mapping;

namespace Store.Services
{
    public interface IProductService : IService
    {
        Task<ProductDto> AddAsync(int userId, ProductDto dto);
        Task<ProductDto> DeleteAsync(int userId, int id);
        Task<ProductDto> GetAsync(int userId, int id);
        Task<IList<ProductDto>> GetAsync(int userId, PagingOptions pagingOptions);
        Task<ProductDto> UpdateAsync(int userId, ProductDto dto);
    }

    public class ProductService : Service, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> AddAsync(int userId, ProductDto dto)
        {
            var model = ProductMapper.Map(dto);
            var newModel = await _productRepository.AddAsync(userId, model);
            var result = ProductDtoMapper.Map(newModel);

            return result;
        }

        public async Task<ProductDto> DeleteAsync(int userId, int id)
        {
            var model = await _productRepository.DeleteAsync(userId, id);
            var result = ProductDtoMapper.Map(model);

            return result;
        }

        public async Task<ProductDto> GetAsync(int userId, int id)
        {
            var model = await _productRepository.GetAsync(userId, id);
            var result = ProductDtoMapper.Map(model);

            return result;
        }

        public async Task<IList<ProductDto>> GetAsync(int userId, PagingOptions pagingOptions)
        {
            var models = await _productRepository.GetAsync(userId, null, pagingOptions);
            var results = ProductDtoMapper.Map(models);

            return results;
        }

        public async Task<ProductDto> UpdateAsync(int userId, ProductDto dto)
        {
            var model = await _productRepository.GetAsync(userId, dto.Id);
            if (model == null)
            {
                return null;
            }

            ProductMapper.Map(dto, model);
            await _productRepository.SaveChangesAsync(userId);

            // Return a fresh copy of the saved object.
            return await GetAsync(userId, model.Id);
        }
    }
}
