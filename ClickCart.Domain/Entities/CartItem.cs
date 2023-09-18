using ClickCart.Domain.Commons;

namespace ClickCart.Domain.Entities;

public class CartItem : Auditable 
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public long ProductQuantity { get; set; }

}
