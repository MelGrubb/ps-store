using System.Threading.Tasks;
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
            await _addressRepository.AddAsync(userId, model);

            // Retrieve a fresh copy of the saved object to return
            model = await _addressRepository.GetAsync(userId, model.Id);
            var result = AddressDtoMapper.Map(model);

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

        public async Task<AddressDto> UpdateAsync(int userId, AddressDto dto)
        {
            var model = await _addressRepository.GetAsync(userId, dto.Id);
            if (model == null)
            {
                return null;
            }

            AddressMapper.Map(dto, model);
            await _addressRepository.SaveChangesAsync(userId);

            model = await _addressRepository.GetAsync(userId, model.Id);
            var result = AddressDtoMapper.Map(model);

            return result;
        }
    }
}
