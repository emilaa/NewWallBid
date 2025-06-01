using MediatR;

namespace WallBid.Business.Modules.ModelModule.Commands.ModelRemoveCommand
{
    public class ModelRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
