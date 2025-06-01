using MediatR;
using WallBid.Infrastructure.Dtos.Color;

namespace WallBid.Business.Modules.ColorModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest : IRequest<ColorGetByIdDto>
    {
        public int Id { get; set; }
    }
}
