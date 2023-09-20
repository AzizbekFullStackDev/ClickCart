using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities
{
    public class Orders : Auditable
    {
        public long UserId { get; set; } // Corrected property name from "User Id" to "UserId"
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public long ProductQuantity { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string street { get; set; }
        public long ZipCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
    }
}
