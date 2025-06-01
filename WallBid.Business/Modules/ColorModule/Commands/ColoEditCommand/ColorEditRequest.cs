using MediatR;

namespace WallBid.Business.Modules.ColorModule.Commands.ColoEditCommand
{
    public class ColorEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
