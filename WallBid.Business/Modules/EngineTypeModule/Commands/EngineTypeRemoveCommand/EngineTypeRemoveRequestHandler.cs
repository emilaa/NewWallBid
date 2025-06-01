using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeRemoveCommand
{
    internal class EngineTypeRemoveRequestHandler : IRequestHandler<EngineTypeRemoveRequest>
    {
        private readonly IEngineTypeRepository _engineTypeRepository;

        public EngineTypeRemoveRequestHandler(IEngineTypeRepository engineTypeRepository)
        {
            _engineTypeRepository = engineTypeRepository;
        }

        public async Task Handle(EngineTypeRemoveRequest request, CancellationToken cancellationToken)
        {
            var existData = _engineTypeRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.DeletedAt = DateTime.Now;

            _engineTypeRepository.Save();
        }
    }
}
