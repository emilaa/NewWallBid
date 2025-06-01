using Microsoft.EntityFrameworkCore;
using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Data.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DbContext dbcontext) : base(dbcontext) { }
    }
}
