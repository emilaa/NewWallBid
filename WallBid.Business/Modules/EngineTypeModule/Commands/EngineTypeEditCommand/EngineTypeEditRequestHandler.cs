using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeEditCommand
{
    internal class EngineTypeEditRequestHandler : IRequestHandler<EngineTypeEditRequest>
    {
        private readonly IEngineTypeRepository _engineTypeRepository;

        public EngineTypeEditRequestHandler(IEngineTypeRepository engineTypeRepository)
        {
            _engineTypeRepository = engineTypeRepository;
        }

        public async Task Handle(EngineTypeEditRequest request, CancellationToken cancellationToken)
        {
            var existData = _engineTypeRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.Type = request.Type;
            existData.LastModifiedAt = DateTime.Now;

            _engineTypeRepository.Save();
        }
    }
}
