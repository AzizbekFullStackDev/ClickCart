using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Categories Category { get; set; }
    public string Brand { get; set; }
    public decimal StockQuantity { get; set; }
    public long SellerId { get; set; } 
}
