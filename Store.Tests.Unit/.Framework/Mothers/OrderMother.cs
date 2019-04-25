using Store.Domain.Models;
using Store.Tests.Unit.Framework.Builders;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class OrderMother
    {
        public static Order Simple()
        {
            return new Order
            {
                BillingAddress = AddressBuilder.Simple().Build(),
                ShippingAddress = AddressBuilder.Simple().Build(),
                OrderStatusId = (int)OrderStatus.Ids.Received,
                User = UserMother.Simple()
            };
        }

        public static Order Typical()
        {
            var result = Simple();

            for (var i = 0; i < GetRandom.Int32(1, 10); i++)
            {
                result.OrderItems.Add(OrderItemMother.Simple());
            }

            return result;
        }
    }
}
