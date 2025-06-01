using MediatR;
using WallBid.Business.Modules.BodyTyperModule.Commands.BodyTypeEditCommand;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeEditCommand
{
    internal class BodyTypeEditRequestHandler : IRequestHandler<BodyTypeEditRequest>
    {
        private readonly IBodyTypeRepository _bodyTypeRepository;
        public BodyTypeEditRequestHandler(IBodyTypeRepository bodyTypeRepository)
        {
            _bodyTypeRepository = bodyTypeRepository;
        }
        public async Task Handle(BodyTypeEditRequest request, CancellationToken cancellationToken)
        {
            var existData = _bodyTypeRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            existData.Name = request.Name;
            _bodyTypeRepository.Save();

        }
    }
}
