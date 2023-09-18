using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities;

public class Registration : Auditable
{
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public Roles Role { get; set; }

}
