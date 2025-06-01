namespace WallBid.Infrastructure.Commons.Concrates
{
    public class BaseEntity<TKey> : AuditableEntity where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
