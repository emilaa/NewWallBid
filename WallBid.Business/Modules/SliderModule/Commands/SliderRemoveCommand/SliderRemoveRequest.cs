using MediatR;

namespace WallBid.Business.Modules.SliderModule.Commands.SliderRemoveCommand
{
    public class SliderRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
