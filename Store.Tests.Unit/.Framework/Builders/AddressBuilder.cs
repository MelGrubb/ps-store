namespace Store.Tests.Unit.Framework.Builders
{
    public partial class AddressBuilder
    {
        public static AddressBuilder JoeCustomerShipping()
        {
            return Simple()
                .WithLine1("123 Any St.")
                .WithLine2("Suite 456")
                .WithCity("Columbus")
                .WithState(() => StateBuilder.Simple().Build())
                .WithPostalCode("43210");
        }

        public static AddressBuilder Simple()
        {
            return Default()
                .WithLine1(() => GetRandom.String(1, 50))
                .WithCity(() => GetRandom.String(1, 50))
                .WithState(() => StateBuilder.Simple().Build())
                .WithPostalCode(() => GetRandom.String(10, 10));
        }

        public static AddressBuilder Typical()
        {
            return Simple()
                .WithLine2(() => GetRandom.String(1, 50));
        }
    }
}
