using System;
using System.Collections.Generic;
using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Builders
{
    public class CountryBuilder
    {
        private Lazy<string> _abbreviation = new Lazy<string>(default(string));
        private Lazy<string> _description = new Lazy<string>(default(string));
        private Lazy<int> _id = new Lazy<int>(default(int));
        private Lazy<string> _name = new Lazy<string>(default(string));
        private Lazy<Country> _object;
        private Lazy<string> _postalCodeLabel = new Lazy<string>(default(string));
        private Lazy<string> _stateLabel = new Lazy<string>(default(string));
        private Lazy<ICollection<State>> _states = new Lazy<ICollection<State>>(default(ICollection<State>));

        public Country Build()
        {
            if (_object == null)
            {
                _object = new Lazy<Country>(new Country
                {
                    Id = _id.Value,
                    Name = _name.Value,
                    Description = _description.Value,
                    StateLabel = _stateLabel.Value,
                    PostalCodeLabel = _postalCodeLabel.Value,
                    Abbreviation = _abbreviation.Value,
                    States = _states.Value
                });
            }

            return _object.Value;
        }

        public static CountryBuilder Default()
        {
            return new CountryBuilder();
        }

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

        public CountryBuilder WithObject(Country value)
        {
            return WithObject(() => value);
        }

        public CountryBuilder WithObject(Func<Country> func)
        {
            _object = new Lazy<Country>(func);
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
