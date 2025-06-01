using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Situation : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
