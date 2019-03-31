using Store.Services.Contracts.State;
using Store.Services.Framework;

namespace Store.Services.Contracts.Address
{
    public class AddressDto : Dto
    {
        public string City { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public StateDto State { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
    }
}
