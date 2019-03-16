using Store.Services.Framework;

namespace Store.Services.Contracts.Product
{
    public class ProductDto : Dto
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductStatusId { get; set; }
    }
}
