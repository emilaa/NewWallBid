using MediatR;
using WallBid.Infrastructure.Dtos.Brand;

namespace WallBid.Business.Modules.BrandModule.Queries.BrandGetAllQuery
{
    public class BrandGetAllRequest : IRequest<IEnumerable<BrandGetAllDto>>
    {

    }
}
