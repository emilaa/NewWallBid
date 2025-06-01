using MediatR;
using Microsoft.AspNetCore.Http;
using WallBid.Infrastructure.Commons.Enums;

namespace WallBid.Business.Modules.CarModule.Commands.CarAddCommand
{
    public class CarAddRequest : IRequest
    {
        public string Description { get; set; }
        //public ICollection<Bid> Bids { get; set; }
        //public ICollection<Model> Models { get; set; } 
        public int LotNumber { get; set; }
        public string Vin { get; set; }
        public int Odometer { get; set; }
        public string PrimaryDamage { get; set; }
        public string SecondryDamage { get; set; }
        public byte Cylinder { get; set; }
        public int EngineTypeId { get; set; }
        public Transmission Transmission { get; set; } //enum +
        public Drive Drive { get; set; } //tam oturucu---enum
        public Fuel Fuel { get; set; } //enum +
        public bool Keys { get; set; }
        public bool Highlight { get; set; } // enum
        public byte Owner { get; set; }
        public bool NewOrOld { get; set; }
        public int ColorId { get; set; }
        public decimal? Price { get; set; } // birbasa satis olarsa (herrac olmadan)
        public int BodyTypeId { get; set; }
        public CountryStore CountryStore { get; set; } //enum-----Hansı bazar üçün yığılıb
        public int Year { get; set; } // buraxilish ili
        public ICollection<int> SituationIds { get; set; }
        public int PlaceCount { get; set; } //enum +
        public ICollection<int> EquipmentIds { get; set; }
        public ICollection<IFormFile> Files { get; set; }
        public string AppUserId { get; set; }
        public AuctionStatus AuctionStatus { get; set; } //enum------auction attend,cancel/win/active bids +
    }
}
