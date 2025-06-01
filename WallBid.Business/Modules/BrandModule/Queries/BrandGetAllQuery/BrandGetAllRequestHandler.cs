using MediatR;
using WallBid.Infrastructure.Dtos.Brand;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BrandModule.Queries.BrandGetAllQuery
{
    internal class BrandGetAllRequestHandler : IRequestHandler<BrandGetAllRequest, IEnumerable<BrandGetAllDto>>
    {
        private readonly IBrandRepository _brandRepository;

        public BrandGetAllRequestHandler(IBrandRepository BrandRepository)
        {
            _brandRepository = BrandRepository;
        }

        public async Task<IEnumerable<BrandGetAllDto>> Handle(BrandGetAllRequest request, CancellationToken cancellationToken)
        {
            var datas = _brandRepository.GetAll(m => m.DeletedAt == null && m.DeletedBy == null)
                .Select(m => new BrandGetAllDto { Id = m.Id, Name = m.Name, Logo = m.Logo });

            return datas;
        }
    }
}
