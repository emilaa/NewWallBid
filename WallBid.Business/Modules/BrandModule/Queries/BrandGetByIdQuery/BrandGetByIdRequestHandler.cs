using MediatR;
using WallBid.Business.Modules.BrandModule.Queries.BrandGetAllQuery;
using WallBid.Infrastructure.Dtos.Brand;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.BrandModule.Modules.BrandGetAllQuery.Queries.SliderGetAllQuery
{
    internal class BrandGetByIdRequestHandler : IRequestHandler<BrandGetByIdRequest, BrandGetByIdDto>
    {

        private readonly IBrandRepository _brandRepository;

        public BrandGetByIdRequestHandler(IBrandRepository BrandRepository)
        {
            _brandRepository = BrandRepository;
        }

        public async Task<BrandGetByIdDto> Handle(BrandGetByIdRequest request, CancellationToken cancellationToken)
        {
            var existData = _brandRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            var dto = new BrandGetByIdDto { Id = existData.Id, Name = existData.Name, Logo = existData.Logo };
            return dto;
        }

    }
}
