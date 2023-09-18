using ClickCart.Domain.Commons;

namespace ClickCart.Domain.Entities;

public class ShippingAddress : Auditable
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public long ZipPostalCode { get; set; }
    public string Country { get; set; }
    public string UserPhoneNumber { get; set; }
}
