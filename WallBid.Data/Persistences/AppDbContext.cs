using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WallBid.Infrastructure.Commons.Abstracts;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Services.Abstracts;

namespace WallBid.Data.Persistences
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        private readonly IDateTimeService _dateTimeService;

        public AppDbContext(
            DbContextOptions options,
            IDateTimeService dateTimeService)
            : base(options)
        {
            _dateTimeService = dateTimeService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();

            if (changes != null)
            {
                foreach (var entry in changes.Where(m => m.State == EntityState.Added || m.State == EntityState.Modified || m.State == EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = "xxx";
                            entry.Entity.CreatedAt = _dateTimeService.ExecutingTime;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = "xxx";
                            entry.Entity.LastModifiedAt = _dateTimeService.ExecutingTime;

                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedBy = "xxx";
                            entry.Entity.DeletedAt = _dateTimeService.ExecutingTime;

                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            entry.Property(m => m.LastModifiedBy).IsModified = false;
                            entry.Property(m => m.LastModifiedAt).IsModified = false;
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
