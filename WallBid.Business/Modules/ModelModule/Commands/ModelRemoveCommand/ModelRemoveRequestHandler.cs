using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ModelModule.Commands.ModelRemoveCommand
{
    internal class ModelRemoveRequestHandler : IRequestHandler<ModelRemoveRequest>
    {
        public readonly IModelRepository _modelRepository;

        public ModelRemoveRequestHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;

        }

        public async Task Handle(ModelRemoveRequest request, CancellationToken cancellationToken)
        {
            var existData = _modelRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.DeletedAt = DateTime.Now;
            _modelRepository.Save();
        }
    }
}
