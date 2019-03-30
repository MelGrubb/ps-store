using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class Address : SoftDeleteableEntity
    {
        public string City { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public State State { get; set; }

        [ForeignKey(nameof(State))]
        public int StateId { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }
    }
}
