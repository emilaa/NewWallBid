using Microsoft.AspNetCore.Identity;
using WallBid.Infrastructure.Commons.Abstracts;

namespace WallBid.Infrastructure.Entities
{
    public class AppUser : IdentityUser, IAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ICollection<Car> Cars { get; set; }
        public Wishlist Wishlist { get; set; }
        //public Image Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
