using MediatR;
using WallBid.Infrastructure.Dtos.Model;

namespace WallBid.Business.Modules.ModelModule.Queries.ModelGetAllQuery
{
    public class ModelGetAllRequest : IRequest<IEnumerable<ModelGetAllDto>>
    {
    }
}
