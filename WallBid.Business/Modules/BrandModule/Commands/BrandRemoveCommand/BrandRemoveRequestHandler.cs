using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand
{
    internal class BrandRemoveRequestHandler : IRequestHandler<BrandRemoveRequest>
    {
        public readonly IBrandRepository _brandRepository;

        public BrandRemoveRequestHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

        }

        public async Task Handle(BrandRemoveRequest request, CancellationToken cancellationToken)
        {
            var existData = _brandRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.DeletedAt = DateTime.Now;
            _brandRepository.Save();
        }
    }
}
