using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class Order : Entity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public Address BillingAddress { get; set; }

        [ForeignKey(nameof(BillingAddress))]
        public int? BillingAddressId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }

        [ForeignKey(nameof(OrderStatus))]
        public int OrderStatusId { get; set; }

        public Address ShippingAddress { get; set; }

        [ForeignKey(nameof(ShippingAddress))]
        public int? ShippingAddressId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
