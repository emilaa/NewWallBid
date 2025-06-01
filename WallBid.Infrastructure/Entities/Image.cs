using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Image : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        //public int AppUserId { get; set; }
        //public AppUser AppUser { get; set; }
    }
}
