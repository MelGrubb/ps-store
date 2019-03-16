using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Common.Contracts;
using Store.Domain.Repositories;
using Store.Services.Contracts.Address;
using Store.Services.Framework;
using Store.Services.Mapping;

namespace Store.Services
{
    public interface IAddressService : IService
    {
        Task<AddressDto> AddAsync(int userId, AddressDto dto);
        Task<AddressDto> DeleteAsync(int userId, int id);
        Task<AddressDto> GetAsync(int userId, int id);
        Task<IList<AddressDto>> GetAsync(int userId, PagingOptions pagingOptions);
        Task<AddressDto> UpdateAsync(int userId, AddressDto dto);
    }

    public class AddressService : Service, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressDto> AddAsync(int userId, AddressDto dto)
        {
            var model = AddressMapper.Map(dto);
            var newModel = await _addressRepository.AddAsync(userId, model);
            var result = AddressDtoMapper.Map(newModel);

            return result;
        }

        public async Task<AddressDto> DeleteAsync(int userId, int id)
        {
            var model = await _addressRepository.DeleteAsync(userId, id);
            var result = AddressDtoMapper.Map(model);

            return result;
        }

        public async Task<AddressDto> GetAsync(int userId, int id)
        {
            var model = await _addressRepository.GetAsync(userId, id);
            var result = AddressDtoMapper.Map(model);

            return result;
        }

        public async Task<IList<AddressDto>> GetAsync(int userId, PagingOptions pagingOptions)
        {
            var models = await _addressRepository.GetAsync(userId, null, pagingOptions);
            var results = AddressDtoMapper.Map(models);

            return results;
        }

        public async Task<AddressDto> UpdateAsync(int userId, AddressDto dto)
        {
            var model = await _addressRepository.GetAsync(userId, dto.Id);
            if (model == null)
            {
                return null;
            }

            AddressMapper.Map(dto, model);
            await _addressRepository.SaveChangesAsync(userId);

            // Return a fresh copy of the saved object.
            return await GetAsync(userId, model.Id);
        }
    }
}
