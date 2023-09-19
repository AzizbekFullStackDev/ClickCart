using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public long ZipPostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public PaymentMethod PaymentInformation { get; set; }
        public Roles UserRole { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
