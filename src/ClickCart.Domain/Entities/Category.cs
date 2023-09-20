using ClickCart.Domain.Commons;

namespace ClickCart.Domain.Entities;

public class Category : Auditable
{
    public Enum CategoryName { get; set; }
    public long ProductId { get; set; }
}
