using MediatR;
using WallBid.Infrastructure.Dtos.EngineType;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.EngineTypeModule.Queries.EngineTypeGetAllQuery
{
    internal class EngineTypeGetAllRequestHandler : IRequestHandler<EngineTypeGetAllRequest, IEnumerable<EngineTypeGetAllDto>>
    {
        private readonly IEngineTypeRepository _engineTypeRepository;

        public EngineTypeGetAllRequestHandler(IEngineTypeRepository engineTypeRepository)
        {
            _engineTypeRepository = engineTypeRepository;
        }

        public async Task<IEnumerable<EngineTypeGetAllDto>> Handle(EngineTypeGetAllRequest request, CancellationToken cancellationToken)
        {
            var existDatas = _engineTypeRepository.GetAll(m => m.DeletedAt == null && m.DeletedBy == null).Select(m => new EngineTypeGetAllDto() { Id = m.Id, Type = m.Type }) ?? throw new NotFoundException("Data not found!");

            return existDatas;
        }
    }
}
