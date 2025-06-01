using MediatR;
using WallBid.Infrastructure.Dtos.BodyType;

namespace WallBid.Business.Modules.BodyTypeModule.Queries.BodyTypeGetAllQuery
{
    public class BodyTypeGetAllRequest : IRequest<IEnumerable<BodyTypeGetAllDto>>
    {
    }
}
