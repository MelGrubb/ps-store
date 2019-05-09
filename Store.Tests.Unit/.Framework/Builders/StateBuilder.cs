using System;
using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Builders
{
    public partial class StateBuilder
    {
        protected override void PostBuild(State value)
        {
            value?.Country?.States?.Add(value);
        }

        public static StateBuilder Simple()
        {
            return Default()
                .WithAbbreviation(GetRandom.String(2, 2))
                .WithName(GetRandom.String(1, 50))
                .WithCountry(CountryBuilder.Simple().Build());
        }

        public static StateBuilder Typical()
        {
            return Simple()
                .WithDescription(GetRandom.String(1, 255));
        }
    }

    public partial class StateBuilder : Builder<State>
    {
        public StateBuilder WithAbbreviation(string value)
        {
            return WithAbbreviation(() => value);
        }

        public StateBuilder WithAbbreviation(Func<string> func)
        {
            _abbreviation = new Lazy<string>(func);
            return this;
        }

        public StateBuilder WithCountry(Country value)
        {
            return WithCountry(() => value);
        }

        public StateBuilder WithCountry(Func<Country> func)
        {
            _country = new Lazy<Country>(func);

            return this;
        }

        public StateBuilder WithCountryId(int value)
        {
            return WithCountryId(() => value);
        }

        public StateBuilder WithCountryId(Func<int> func)
        {
            _countryId = new Lazy<int>(func);
            return this;
        }

        public StateBuilder WithDescription(string value)
        {
            return WithDescription(() => value);
        }

        public StateBuilder WithDescription(Func<string> func)
        {
            _description = new Lazy<string>(func);
            return this;
        }

        public StateBuilder WithId(int value)
        {
            return WithId(() => value);
        }

        public StateBuilder WithId(Func<int> func)
        {
            _id = new Lazy<int>(func);
            return this;
        }

        public StateBuilder WithName(string value)
        {
            return WithName(() => value);
        }

        public StateBuilder WithName(Func<string> func)
        {
            _name = new Lazy<string>(func);
            return this;
        }

        public StateBuilder WithoutCountry()
        {
            _country = new Lazy<Country>((Country)null);
            return this;
        }
    }
}
