using MediatR;
using WallBid.Infrastructure.Dtos.EngineType;

namespace WallBid.Business.Modules.EngineTypeModule.Queries.EngineTypeGetByIdQuery
{
    public class EngineTypeGetByIdRequest : IRequest<EngineTypeGetByIdDto>
    {
        public int Id { get; set; }
    }
}
