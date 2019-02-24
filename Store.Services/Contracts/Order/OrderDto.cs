using System.Collections.Generic;
using Store.Services.Contracts.User;
using Store.Services.Framework;

namespace Store.Services.Contracts.Order
{
    public class OrderDto : Dto
    {
        public OrderDto()
        {
            OrderItems = new HashSet<OrderItemDto>();
        }

        public ICollection<OrderItemDto> OrderItems { get; set; }
        public OrderStatusDto OrderStatus { get; set; }
        public UserDto User { get; set; }
    }
}
