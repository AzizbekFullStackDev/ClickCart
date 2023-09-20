using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities;

public class ProductMerchentConnection : Auditable
{
    public long ProductId { get; set; }
    public long MerchantId { get; set; }
    public string MerchantName { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public Categories ProductCategory { get; set; }
    public string ProductBrand { get; set; }
    public decimal ProductStockQuantity { get; set; }
}
