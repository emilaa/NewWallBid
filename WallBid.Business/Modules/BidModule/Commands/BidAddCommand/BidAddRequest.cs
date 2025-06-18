using MediatR;

namespace WallBid.Business.Modules.BidModule.Commands.BidAddCommand
{
    public class BidAddRequest : IRequest
    {
        public decimal Price { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
