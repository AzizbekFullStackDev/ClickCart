using ClickCart.Domain.Commons;

namespace ClickCart.Domain.Entities;

public class Category : Auditable
{
    public string Name { get; set; }
    public long ProductId { get; set; }
}
