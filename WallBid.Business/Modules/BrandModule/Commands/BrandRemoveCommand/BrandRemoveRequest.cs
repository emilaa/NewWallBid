using MediatR;

namespace WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand
{
    public class BrandRemoveRequest : IRequest
    {
        public int Id { get; set; }

    }
}
