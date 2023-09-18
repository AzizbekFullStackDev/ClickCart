using ClickCart.Domain.Commons;

namespace ClickCart.Domain.Entities
{
    public class Coupon : Auditable
    {
        public long UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal CouponAmount { get; set; }
    }
}
