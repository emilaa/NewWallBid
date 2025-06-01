using MediatR;
using WallBid.Infrastructure.Dtos.Slider;

namespace WallBid.Business.Modules.SliderModule.Queries.SliderGetAllQuery
{
    public class SliderGetAllRequest : IRequest<IEnumerable<SliderGetAllDto>>
    {

    }
}
