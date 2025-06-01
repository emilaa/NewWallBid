using MediatR;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ModelModule.Commands.ModelAddCommand
{
    internal class ModelAddRequestHandler : IRequestHandler<ModelAddRequest>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IBrandRepository _brandRepository;

        public ModelAddRequestHandler(IModelRepository modelRepository, IBrandRepository brandRepository)
        {
            _modelRepository = modelRepository;
            _brandRepository = brandRepository;
        }

        public async Task Handle(ModelAddRequest request, CancellationToken cancellationToken)
        {

            Model model = new()
            {
                Name = request.Name,
                BrandId = request.BrandId
            };
            _modelRepository.Add(model);
            _modelRepository.Save();
        }
    }
}
