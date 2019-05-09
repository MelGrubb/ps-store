using System;
using System.Collections.Generic;
using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Builders
{
    public partial class CountryBuilder
    {
        public static CountryBuilder Simple()
        {
            return Default()
                .WithAbbreviation(GetRandom.String(2, 2))
                .WithName(GetRandom.String(1, 50));
        }

        public static CountryBuilder Typical()
        {
            return Simple()
                .WithDescription(GetRandom.String(1, 255));
        }
    }

    public partial class CountryBuilder : Builder<Country>
    {
        public CountryBuilder WithAbbreviation(string value)
        {
            return WithAbbreviation(() => value);
        }

        public CountryBuilder WithAbbreviation(Func<string> func)
        {
            _abbreviation = new Lazy<string>(func);
            return this;
        }

        public CountryBuilder WithDescription(string value)
        {
            return WithDescription(() => value);
        }

        public CountryBuilder WithDescription(Func<string> func)
        {
            _description = new Lazy<string>(func);
            return this;
        }

        public CountryBuilder WithId(int value)
        {
            return WithId(() => value);
        }

        public CountryBuilder WithId(Func<int> func)
        {
            _id = new Lazy<int>(func);
            return this;
        }

        public CountryBuilder WithName(string value)
        {
            return WithName(() => value);
        }

        public CountryBuilder WithName(Func<string> func)
        {
            _name = new Lazy<string>(func);
            return this;
        }

        public CountryBuilder WithPostalCodeLabel(string value)
        {
            return WithPostalCodeLabel(() => value);
        }

        public CountryBuilder WithPostalCodeLabel(Func<string> func)
        {
            _postalCodeLabel = new Lazy<string>(func);
            return this;
        }

        public CountryBuilder WithStateLabel(string value)
        {
            return WithStateLabel(() => value);
        }

        public CountryBuilder WithStateLabel(Func<string> func)
        {
            _stateLabel = new Lazy<string>(func);
            return this;
        }

        public CountryBuilder WithStates(ICollection<State> value)
        {
            return WithStates(() => value);
        }

        public CountryBuilder WithStates(Func<ICollection<State>> func)
        {
            _states = new Lazy<ICollection<State>>(func);
            return this;
        }
    }
}
