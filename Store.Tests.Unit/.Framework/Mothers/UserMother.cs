using Store.Domain.Models;
using Store.Tests.Unit.Framework.Builders;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class UserMother
    {
        public static User Simple()
        {
            return new User
            {
                Address = AddressBuilder.Simple().Build(),
                FirstName = GetRandom.FirstName(),
                LastName = GetRandom.LastName(),
                MiddleName = GetRandom.FirstName(),
                PasswordHash = GetRandom.String(),
                PhoneNumber = GetRandom.String(10, 10),
                UserName = GetRandom.String(1, 20)
            };
        }

        public static User Typical()
        {
            return Simple();
        }
    }
}
