using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities;

public class Merchant : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string MerchantDecription { get; set; }
    public Roles Role { get; set; }
    public string PhoneNumber { get; set; }

}
