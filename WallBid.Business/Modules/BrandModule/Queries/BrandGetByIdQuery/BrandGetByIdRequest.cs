using MediatR;
using WallBid.Infrastructure.Dtos.Brand;

namespace WallBid.Business.Modules.BrandModule.Queries.BrandGetAllQuery
{
    public class BrandGetByIdRequest : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }
    }
}
