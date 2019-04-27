using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Builders
{
    public class CountryBuilder
    {
        private readonly Country _object = new Country();

        public Country Build()
        {
            return _object;
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
            _object.Abbreviation = value;
            return this;
        }

        public CountryBuilder WithName(string value)
        {
            _object.Name = value;
            return this;
        }

        public CountryBuilder WithDescription(string value)
        {
            _object.Description = value;
            return this;
        }

        public CountryBuilder WithId(int value)
        {
            _object.Id = value;
            return this;
        }

        public CountryBuilder WithPostalCodeLabel(string value)
        {
            _object.PostalCodeLabel = value;
            return this;
        }

        public CountryBuilder WithStateLabel(string value)
        {
            _object.StateLabel = value;
            return this;
        }
    }
}
