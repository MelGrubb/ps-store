using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class StateMother
    {
        public static State Simple()
        {
            var result = new State
            {
                Abbreviation = GetRandom.String(2, 2),
                Name = GetRandom.String(1, 50),
                Country = CountryMother.Simple()
            };

            result.Country.States.Add(result);

            return result;
        }

        public static State Typical()
        {
            var result = Simple();
            result.Description = GetRandom.String(1, 255);

            return result;
        }
    }
}
