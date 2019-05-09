using System;
using Store.Domain.Models;

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

    public partial class AddressBuilder : Builder<Address>
    {
        public AddressBuilder WithCity(string value)
        {
            return WithCity(() => value);
        }

        public AddressBuilder WithCity(Func<string> func)
        {
            _city = new Lazy<string>(func);
            return this;
        }

        public AddressBuilder WithId(int value)
        {
            return WithId(() => value);
        }

        public AddressBuilder WithId(Func<int> func)
        {
            _id = new Lazy<int>(func);
            return this;
        }

        public AddressBuilder WithLine1(string value)
        {
            return WithLine1(() => value);
        }

        public AddressBuilder WithLine1(Func<string> func)
        {
            _line1 = new Lazy<string>(func);
            return this;
        }

        public AddressBuilder WithLine2(string value)
        {
            return WithLine2(() => value);
        }

        public AddressBuilder WithLine2(Func<string> func)
        {
            _line2 = new Lazy<string>(func);
            return this;
        }

        public AddressBuilder WithPostalCode(string value)
        {
            return WithPostalCode(() => value);
        }

        public AddressBuilder WithPostalCode(Func<string> func)
        {
            _postalCode = new Lazy<string>(func);
            return this;
        }

        public AddressBuilder WithState(State value)
        {
            return WithState(() => value);
        }

        public AddressBuilder WithState(Func<State> func)
        {
            _state = new Lazy<State>(func);
            return this;
        }
    }
}
