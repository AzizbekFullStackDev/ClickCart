using ClickCart.Domain.Commons;

namespace ClickCart.Domain.Entities
{
    public class TopRating : Auditable
    {
        public long UserId { get; set; }
        public TopRating Rating { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
