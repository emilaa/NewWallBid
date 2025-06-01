using MediatR;

namespace WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeAddCommand
{
    public class BodyTypeAddRequest : IRequest
    {
        public string Name { get; set; }
    }
}
