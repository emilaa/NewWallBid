using MediatR;

namespace WallBid.Business.Modules.BodyTypeModule.Commands.BodyTypeRemoveCommand
{
    public class BodyTypeRemoveRequest : IRequest
    {
        public int Id { get; set; }

    }
}
