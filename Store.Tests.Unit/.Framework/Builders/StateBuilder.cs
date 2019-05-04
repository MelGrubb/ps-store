using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Builders
{
    public class StateBuilder
    {
        private readonly State _object = new State();

        public State Build()
        {
            _object?.Country?.States?.Add(_object);

            return _object;
        }

        public static StateBuilder Default()
        {
            return new StateBuilder();
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

        public StateBuilder WithAbbreviation(string value)
        {
            _object.Abbreviation = value;
            return this;
        }

        public StateBuilder WithName(string value)
        {
            _object.Name = value;
            return this;
        }

        public StateBuilder WithDescription(string value)
        {
            _object.Description = value;
            return this;
        }

        public StateBuilder WithCountry(Country value)
        {
            _object.Country = value;
            _object.CountryId = value?.Id ?? 0;
            return this;
        }

        public StateBuilder WithCountryId(int value)
        {
            _object.CountryId = value;
            _object.Country = null;
            return this;
        }

        public StateBuilder WithoutCountry()
        {
            _object.Country = null;
            _object.CountryId = 0;
            return this;
        }
    }
}
