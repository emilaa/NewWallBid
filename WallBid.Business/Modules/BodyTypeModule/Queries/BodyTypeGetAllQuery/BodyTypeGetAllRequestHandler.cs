using MediatR;
using WallBid.Infrastructure.Dtos.BodyType;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BodyTypeModule.Queries.BodyTypeGetAllQuery
{
    internal class BodyTypeGetAllRequestHandler : IRequestHandler<BodyTypeGetAllRequest, IEnumerable<BodyTypeGetAllDto>>
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        public BodyTypeGetAllRequestHandler(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }
        public async Task<IEnumerable<BodyTypeGetAllDto>> Handle(BodyTypeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = _bodyTypeRepository.GetAll(m => m.DeletedAt == null && m.DeletedBy == null)
                .Select(m => new BodyTypeGetAllDto { Id = m.Id, Name = m.Name });
            return data;
        }
    }
}
