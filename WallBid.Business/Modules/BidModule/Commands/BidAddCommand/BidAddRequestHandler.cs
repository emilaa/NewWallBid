using MediatR;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BidModule.Commands.BidAddCommand
{
    internal class BidAddRequestHandler : IRequestHandler<BidAddRequest>
    {
        private readonly IBidRepository _bidRepository;

        public BidAddRequestHandler(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task Handle(BidAddRequest request, CancellationToken cancellationToken)
        {
            Bid newBid = new()
            {
                Price = request.Price,
                CarId = request.CarId,
                StartDate = request.StartDate
            };

            _bidRepository.Add(newBid);
            _bidRepository.Save();
        }
    }
}
