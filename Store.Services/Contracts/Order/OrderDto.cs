using System.Collections.Generic;
using Store.Services.Contracts.Address;
using Store.Services.Framework;

namespace Store.Services.Contracts.Order
{
    public class OrderDto : Dto
    {
        public OrderDto()
        {
            OrderItems = new HashSet<OrderItemDto>();
        }

        public AddressDto BillingAddress { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public int OrderStatusId { get; set; }
        public AddressDto ShippingAddress { get; set; }
        public int UserId { get; set; }
    }
}
