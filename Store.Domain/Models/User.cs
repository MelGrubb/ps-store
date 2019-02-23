using Store.Domain.Framework;

namespace Store.Domain.Models
{
    public class User : SoftDeleteableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
