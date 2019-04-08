using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class ProductMother
    {
        public static Product BackOrdered()
        {
            var result = Simple();
            result.ProductStatus = null;
            result.ProductStatusId = (int)ProductStatus.Ids.BackOrdered;

            return result;
        }

        public static Product Simple()
        {
            return new Product
            {
                Name = GetRandom.String(1, 50),
                Category = CategoryMother.Simple(),
                Description = GetRandom.String(1, 255),
                Price = GetRandom.Decimal(1, 10),
                ProductStatus = ProductStatusMother.Simple()
            };
        }

        public static Product Typical()
        {
            return Simple();
        }
    }
}
