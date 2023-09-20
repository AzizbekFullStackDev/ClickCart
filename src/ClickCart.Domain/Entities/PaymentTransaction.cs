using ClickCart.Domain.Commons;
using ClickCart.Domain.Enums;

namespace ClickCart.Domain.Entities
{
    public class PaymentTransaction : Auditable
    {
        public long UserId { get; set; }
        public long OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TransactionAmount { get; set; }

    }
}
