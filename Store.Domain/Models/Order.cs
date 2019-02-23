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

        public ICollection<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }

        [ForeignKey(nameof(OrderStatus))]
        public int OrderStatusId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}
