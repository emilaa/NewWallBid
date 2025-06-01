using Microsoft.EntityFrameworkCore;
using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Data.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(DbContext dbcontext) : base(dbcontext) { }
    }
}
