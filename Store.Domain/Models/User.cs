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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
