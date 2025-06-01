using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Color : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
