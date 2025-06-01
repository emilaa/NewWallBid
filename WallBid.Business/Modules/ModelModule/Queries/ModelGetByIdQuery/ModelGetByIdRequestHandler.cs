using MediatR;
using WallBid.Infrastructure.Dtos.Model;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ModelModule.Queries.ModelGetByIdQuery
{
    internal class ModelGetByIdRequestHandler : IRequestHandler<ModelGetByIdRequest, ModelGetByIdDto>
    {
        private readonly IModelRepository _modelRepository;

        public ModelGetByIdRequestHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<ModelGetByIdDto> Handle(ModelGetByIdRequest request, CancellationToken cancellationToken)
        {
            var existData = _modelRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            var dto = new ModelGetByIdDto { Id = existData.Id, Name = existData.Name, BrandId = existData.BrandId };
            return dto;
        }
    }
}
