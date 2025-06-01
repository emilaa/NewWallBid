using MediatR;
using WallBid.Infrastructure.Dtos.Slider;

namespace WallBid.Business.Modules.SliderModule.Queries.SliderGetByIdQuery
{
    public class SliderGetByIdRequest : IRequest<SliderGetByIdDto>
    {
        public int Id { get; set; }
    }
}
