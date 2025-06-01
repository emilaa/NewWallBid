using Microsoft.EntityFrameworkCore;
using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext dbcontext) : base(dbcontext) { }
    }
}
