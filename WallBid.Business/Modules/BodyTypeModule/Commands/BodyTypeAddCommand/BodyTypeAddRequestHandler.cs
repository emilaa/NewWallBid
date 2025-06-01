using MediatR;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeAddCommand
{
    internal class BodyTypeAddRequestHandler : IRequestHandler<BodyTypeAddRequest>
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        public BodyTypeAddRequestHandler(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }

        public async Task Handle(BodyTypeAddRequest request, CancellationToken cancellationToken)
        {
            BodyType bodyType = new()
            {
                Name = request.Name,
            };
            _bodyTypeRepository.Add(bodyType);
            _bodyTypeRepository.Save();
        }
    }
}
