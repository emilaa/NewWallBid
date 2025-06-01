using MediatR;
using WallBid.Infrastructure.Dtos.Model;

namespace WallBid.Business.Modules.ModelModule.Queries.ModelGetByIdQuery
{
    public class ModelGetByIdRequest : IRequest<ModelGetByIdDto>
    {
        public int Id { get; set; }
    }
}
