using Store.Domain.Models;

namespace Store.Tests.Unit.Framework.Mothers
{
    public static class ProductStatusMother
    {
        public static ProductStatus Simple()
        {
            return new ProductStatus
            {
                Name = GetRandom.String(1, 50)
            };
        }

        public static ProductStatus Typical()
        {
            var result = Simple();
            result.Description = GetRandom.String(1, 255);

            return result;
        }
    }
}
