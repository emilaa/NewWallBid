using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeRemoveCommand
{
    internal class BodyTypeRemoveRequestHandler : IRequestHandler<BodyTypeRemoveRequest>
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;

        public BodyTypeRemoveRequestHandler(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }
        public async Task Handle(BodyTypeRemoveRequest request, CancellationToken cancellationToken)
        {
            var existData = _bodyTypeRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.DeletedAt = DateTime.Now;
            _bodyTypeRepository.Save();
        }
    }
}
