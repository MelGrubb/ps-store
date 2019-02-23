using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class ProductStatus : Lookup
    {
        public enum Ids
        {
            Unknown = 0,
            InStock = 1,
            BackOrdered = 2,
            Discontinued = 3
        }
    }
}
