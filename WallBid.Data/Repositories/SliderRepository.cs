using Microsoft.EntityFrameworkCore;
using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Data.Repositories
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(DbContext dbcontext) : base(dbcontext) { }
    }
}
