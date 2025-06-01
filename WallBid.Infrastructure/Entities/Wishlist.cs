using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Wishlist : BaseEntity<int>
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        //public ICollection<WishlistItem> WishlistItems { get; set; }


    }
}
