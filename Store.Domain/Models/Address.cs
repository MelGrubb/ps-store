using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class Address : SoftDeleteableEntity
    {
        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Line1 { get; set; }

        [MaxLength(50)]
        public string Line2 { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        public State State { get; set; }

        [ForeignKey(nameof(State))]
        public int StateId { get; set; }
    }
}
