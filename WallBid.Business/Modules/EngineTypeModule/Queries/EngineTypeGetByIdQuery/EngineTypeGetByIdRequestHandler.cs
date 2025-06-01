using MediatR;
using WallBid.Infrastructure.Dtos.EngineType;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.EngineTypeModule.Queries.EngineTypeGetByIdQuery
{
    internal class EngineTypeGetByIdRequestHandler : IRequestHandler<EngineTypeGetByIdRequest, EngineTypeGetByIdDto>
    {
        private readonly IEngineTypeRepository _engineTypeRepository;

        public EngineTypeGetByIdRequestHandler(IEngineTypeRepository engineTypeRepository)
        {
            _engineTypeRepository = engineTypeRepository;
        }

        public async Task<EngineTypeGetByIdDto> Handle(EngineTypeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var existData = _engineTypeRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            var dto = new EngineTypeGetByIdDto() { Id = existData.Id, Type = existData.Type };

            return dto;
        }
    }
}
