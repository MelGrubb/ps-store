using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class OrderItemMother
    {
        public static OrderItem Simple()
        {
            return new OrderItem
            {
                Price = GetRandom.Decimal(1, 10),
                Product = ProductMother.Simple(),
                Quantity = GetRandom.Int32(1, 10)
            };
        }

        public static OrderItem Typical()
        {
            return Simple();
        }
    }
}
