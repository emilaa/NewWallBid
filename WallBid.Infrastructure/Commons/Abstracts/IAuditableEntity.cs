namespace WallBid.Infrastructure.Commons.Abstracts
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        string? LastModifiedBy { get; set; }
        DateTime? LastModifiedAt { get; set; }
        string? DeletedBy { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
