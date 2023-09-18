using ClickCart.Domain.Enums;

namespace ClickCart.Service.DTOs.Merchant
{
    public class MerchantForUpdateDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MerchantDecription { get; set; }
        public Roles Role { get; set; }
        public string PhoneNumber { get; set; }
        public Rating MerchantRating { get; set; }
    }
}
