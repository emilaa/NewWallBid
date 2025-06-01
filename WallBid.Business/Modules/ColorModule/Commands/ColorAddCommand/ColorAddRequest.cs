using MediatR;

namespace WallBid.Business.Modules.ColorModule.Commands.ColorAddCommand
{
    public class ColorAddRequest : IRequest
    {
        public string Name { get; set; }
    }
}
