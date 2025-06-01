using MediatR;

namespace WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeRemoveCommand
{
    public class EngineTypeRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
