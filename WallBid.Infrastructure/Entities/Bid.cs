using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Bid : BaseEntity<int>
    {
        public decimal Price { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsEnable { get; set; } = false;
    }
}
