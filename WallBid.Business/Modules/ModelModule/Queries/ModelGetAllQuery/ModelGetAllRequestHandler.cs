using MediatR;
using WallBid.Infrastructure.Dtos.Model;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ModelModule.Queries.ModelGetAllQuery
{
    internal class ModelGetAllRequestHandler : IRequestHandler<ModelGetAllRequest, IEnumerable<ModelGetAllDto>>
    {
        private readonly IModelRepository _modelRepository;

        public ModelGetAllRequestHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<IEnumerable<ModelGetAllDto>> Handle(ModelGetAllRequest request, CancellationToken cancellationToken)
        {
            var datas = _modelRepository.GetAll(m => m.DeletedAt == null && m.DeletedBy == null)
                .Select(m => new ModelGetAllDto { Id = m.Id, Name = m.Name, BrandId = m.BrandId });

            return datas;
        }
    }
}
