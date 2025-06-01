using MediatR;
using WallBid.Infrastructure.Dtos.BodyType;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BodyTypeModule.Queries.BodyTypeGetByIdQuery
{
    public class BodyTypeGetByIdRequestHandler : IRequestHandler<BodyTypeGetByIdRequest, BodyTypeGetByIdDto>
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        public BodyTypeGetByIdRequestHandler(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }
        public async Task<BodyTypeGetByIdDto> Handle(BodyTypeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var existData = _bodyTypeRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            BodyTypeGetByIdDto dto = new BodyTypeGetByIdDto { Id = existData.Id, Name = existData.Name };
            return dto;
        }
    }
}
