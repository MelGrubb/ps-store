using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class CategoryMother
    {
        public static Category Simple()
        {
            return new Category
            {
                Name = GetRandom.String(1, 50)
            };
        }

        public static Category Typical()
        {
            var result = Simple();
            result.Description = GetRandom.String(1, 255);

            for (var i = 0; i < GetRandom.Int32(1, 10); i++)
            {
                result.ChildCategories.Add(Simple());
            }

            return result;
        }
    }
}
