using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class StateMother
    {
        public static State Simple()
        {
            return new State
            {
                Abbreviation = GetRandom.String(2, 2),
                Name = GetRandom.String(1, 50)
            };
        }

        public static State Typical()
        {
            var result = Simple();
            result.Description = GetRandom.String(1, 255);

            return result;
        }
    }
}
