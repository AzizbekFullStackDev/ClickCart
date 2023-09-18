using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities;

public class Orders : Auditable
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public decimal TotalAmount { get; set; }
    public long ProductQuantity { get; set; }
    public string ShippingAddressId { get; set; }
    public PaymentMethod Paymentinfo { get; set; }
    public string OrderStatus { get; set; }

}
