using WallBid.Infrastructure.Services.Abstracts;

namespace WallBid.Infrastructure.Services.Concrates
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }

    public class UtcDateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
