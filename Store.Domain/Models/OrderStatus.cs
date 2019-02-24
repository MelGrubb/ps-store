using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class OrderStatus : Lookup
    {
        public enum Ids
        {
            Unknown = 0,
            Received = 1,
            Processing = 2,
            Shipping = 3,
            Shipped = 4
        }
    }
}
