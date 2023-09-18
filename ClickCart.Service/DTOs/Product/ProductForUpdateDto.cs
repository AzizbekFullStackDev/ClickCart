using ClickCart.Domain.Enums;

namespace ClickCart.Service.DTOs.Product
{
    public class ProductForUpdateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Categories Category { get; set; }
        public string Brand { get; set; }
        public decimal StockQuantity { get; set; }
        public long SellerId { get; set; }

    }
}
