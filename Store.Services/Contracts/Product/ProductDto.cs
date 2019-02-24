using Store.Services.Contracts.Category;
using Store.Services.Framework;

namespace Store.Services.Contracts.Product
{
    public class ProductDto : Dto
    {
        public CategoryDto Category { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductStatusDto ProductStatus { get; set; }
    }
}
