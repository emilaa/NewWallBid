using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Model : BaseEntity<int>
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
