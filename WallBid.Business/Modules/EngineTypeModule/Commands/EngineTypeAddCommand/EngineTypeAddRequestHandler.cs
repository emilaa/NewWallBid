using MediatR;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeAddCommand
{
    internal class EngineTypeAddRequestHandler : IRequestHandler<EngineTypeAddRequest>
    {
        private readonly IEngineTypeRepository _engineTypeRepository;

        public EngineTypeAddRequestHandler(IEngineTypeRepository engineTypeRepository)
        {
            _engineTypeRepository = engineTypeRepository;
        }

        public async Task Handle(EngineTypeAddRequest request, CancellationToken cancellationToken)
        {
            var data = new EngineType() { Type = request.Type };
            _engineTypeRepository.Add(data);
            _engineTypeRepository.Save();
        }
    }
}
