using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ModelModule.Commands.ModelEditCommand
{
    internal class ModelEditRequestHandler : IRequestHandler<ModelEditRequest>
    {
        public readonly IModelRepository _modelRepository;

        public ModelEditRequestHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task Handle(ModelEditRequest request, CancellationToken cancellationToken)
        {
            var existData = _modelRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.Name = request.Name;
            existData.BrandId = request.BrandId;

            _modelRepository.Save();
        }
    }
}
