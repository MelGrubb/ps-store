using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class Product : SoftDeleteableEntity
    {
        public Category Category { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public ProductStatus ProductStatus { get; set; }

        [ForeignKey(nameof(ProductStatus))]
        public int ProductStatusId { get; set; }
    }
}
