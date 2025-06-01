using Microsoft.EntityFrameworkCore;
using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Data.Repositories
{
    public class AdditionalInformationRepository : Repository<AdditionalInformation>, IAdditionalInformationRepository
    {
        public AdditionalInformationRepository(DbContext db) : base(db) { }
    }
}
