using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class User : SoftDeleteableEntity
    {
        public enum Ids
        {
            Unknown = 0,
            Admin = 1,
            SampleCustomer = 2
        }

        public Address Address { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }
    }
}
