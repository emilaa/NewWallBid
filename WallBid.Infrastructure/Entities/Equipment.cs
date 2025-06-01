using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Equipment : BaseEntity<int>
    {
        public string Name { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
