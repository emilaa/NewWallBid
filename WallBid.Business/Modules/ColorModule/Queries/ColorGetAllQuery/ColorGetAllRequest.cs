using MediatR;
using WallBid.Infrastructure.Dtos.Color;

namespace WallBid.Business.Modules.ColorModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<ColorGetAllDto>>
    {
    }
}
