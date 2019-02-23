using Store.Domain.Models;
using Store.Services.Contracts.Address;

namespace Store.Services.Mapping
{
    public class AddressDtoMapper : Mapper<Address, AddressDto>
    {
        public AddressDtoMapper()
        {
            CreateMap()
                .ForMember(d => d.State, o => o.MapFrom(s => s.State.Name));
        }
    }
}
