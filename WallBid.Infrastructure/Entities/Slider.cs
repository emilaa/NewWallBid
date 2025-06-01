using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Slider : BaseEntity<int>
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

    }
}
