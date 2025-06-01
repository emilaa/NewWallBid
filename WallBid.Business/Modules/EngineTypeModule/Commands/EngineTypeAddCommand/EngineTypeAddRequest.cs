using MediatR;

namespace WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeAddCommand
{
    public class EngineTypeAddRequest : IRequest
    {
        public double Type { get; set; }
    }
}
