using MediatR;

namespace WallBid.Business.Modules.EngineTypeModule.Commands.EngineTypeEditCommand
{
    public class EngineTypeEditRequest : IRequest
    {
        public int Id { get; set; }
        public double Type { get; set; }
    }
}
