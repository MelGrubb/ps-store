using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class Product : SoftDeleteableEntity
    {
        public Category Category { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductStatus ProductStatus { get; set; }

        [ForeignKey(nameof(ProductStatus))]
        public int ProductStatusId { get; set; }
    }
}
