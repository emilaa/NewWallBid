using WallBid.Infrastructure.Commons.Concrates;
using WallBid.Infrastructure.Commons.Enums;

namespace WallBid.Infrastructure.Entities
{
    public class Car : BaseEntity<int>
    {
        public string Description { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int LotNumber { get; set; }
        public string Vin { get; set; }
        public int Odometer { get; set; }
        public string PrimaryDamage { get; set; }
        public string SecondryDamage { get; set; }
        public byte Cylinder { get; set; }
        public int EngineTypeId { get; set; }
        public EngineType EngineType { get; set; }
        public Transmission Transmission { get; set; } //enum +
        public Drive Drive { get; set; } //tam oturucu---enum
        public Fuel Fuel { get; set; } //enum +
        public bool Keys { get; set; }
        public bool Highlight { get; set; } // control car, example: Run and drive
        public byte Owner { get; set; }
        public bool NewOrOld { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public decimal? Price { get; set; } // birbasa satis olarsa (herrac olmadan)

        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; } //sedan

        public CountryStore CountryStore { get; set; } //enum-----Hansı bazar üçün yığılıb
        public int Year { get; set; } // buraxilish ili

        public ICollection<Situation> Situations { get; set; }
        public PlaceCount PlaceCount { get; set; } //enum +
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<Image> Images { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public AuctionStatus AuctionStatus { get; set; } //enum------auction attend,cancel/win/active bids +
        //public ICollection<WishlistItem> WishlistItems { get; set; }






    }
}
