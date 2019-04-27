using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class CountryMother
    {
        public static Country Simple()
        {
            return new Country
            {
                Name = GetRandom.String(1, 50)
            };
        }

        public static Country Typical()
        {
            var result = Simple();
            result.Description = GetRandom.String(1, 255);

            return result;
        }
    }
}
