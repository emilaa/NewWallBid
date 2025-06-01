using WallBid.Infrastructure.Commons.Abstracts;

namespace WallBid.Infrastructure.Commons.Concrates
{
    public class AuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
