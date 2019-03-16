using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.Contracts;
using Store.Domain.Repositories;
using Store.Services.Contracts.Country;
using Store.Services.Framework;
using Store.Services.Mapping;

namespace Store.Services
{
    public interface ICountryService : IService
    {
        Task<CountryDto> GetAsync(int userId, int id);
        Task<IList<CountryDto>> GetAsync(int userId, PagingOptions pagingOptions);
    }

    public class CountryService : Service, ICountryService
    {
        private readonly ICountryRepository _addressRepository;

        public CountryService(ICountryRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<CountryDto> GetAsync(int userId, int id)
        {
            var model = await _addressRepository.GetAsync(userId, id);
            var result = CountryDtoMapper.Map(model);

            return result;
        }

        public async Task<IList<CountryDto>> GetAsync(int userId, PagingOptions pagingOptions)
        {
            var models = await _addressRepository.GetAsync(userId, null, pagingOptions);
            var results = CountryDtoMapper.Map(models);

            return results;
        }
    }
}
