using MediatR;
using WallBid.Infrastructure.Dtos.EngineType;

namespace WallBid.Business.Modules.EngineTypeModule.Queries.EngineTypeGetAllQuery
{
    public class EngineTypeGetAllRequest : IRequest<IEnumerable<EngineTypeGetAllDto>>
    {
    }
}
