using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class Category : Lookup
    {
        public enum Ids
        {
            Unknown = 0,
            Clothing = 1,
            Mens = 2,
            Womens = 3
        }

        public Category()
        {
            ChildCategories = new HashSet<Category>();
        }

        public ICollection<Category> ChildCategories { get; set; }
        public Category ParentCategory { get; set; }

        [ForeignKey(nameof(ParentCategory))]
        public int? ParentCategoryId { get; set; }
    }
}
