using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class WishlistItem : BaseEntity<int>
    {
        //public int WishlistId { get; set; }
        //public Wishlist Wishlist { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
