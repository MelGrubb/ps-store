using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class AddressMother
    {
        public static Address Simple()
        {
            return new Address
            {
                Line1 = GetRandom.String(),
                City = GetRandom.String(),
                State = StateMother.Simple(),
                PostalCode = GetRandom.String(10, 10)
            };
        }

        public static Address Typical()
        {
            var result = Simple();
            result.Line2 = GetRandom.String(1, 50);

            return result;
        }

        public static Address JoeCustomerShippingAddress()
        {
            var result = Simple();
            result.Line1 = "123 Any St.";
            result.Line2 = "Suite 456";
            result.City = "Columbus";
            result.StateId = 35;
            result.PostalCode = "43210";

            return result;
        }
    }
}
