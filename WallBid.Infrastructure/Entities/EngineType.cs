using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class EngineType : BaseEntity<int>
    {
        public double Type { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
