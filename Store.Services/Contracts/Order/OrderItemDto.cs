using Store.Services.Contracts.Product;
using Store.Services.Framework;

namespace Store.Services.Contracts.Order
{
    public class OrderItemDto : Dto
    {
        public decimal Price { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
