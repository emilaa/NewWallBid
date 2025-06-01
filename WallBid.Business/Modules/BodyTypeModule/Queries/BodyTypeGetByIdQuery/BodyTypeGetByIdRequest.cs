using MediatR;
using WallBid.Infrastructure.Dtos.BodyType;

namespace WallBid.Business.Modules.BodyTypeModule.Queries.BodyTypeGetByIdQuery
{
    public class BodyTypeGetByIdRequest : IRequest<BodyTypeGetByIdDto>
    {
        public int Id { get; set; }
    }
}
