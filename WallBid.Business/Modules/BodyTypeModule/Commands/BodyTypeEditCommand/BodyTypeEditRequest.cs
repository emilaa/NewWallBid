using MediatR;

namespace WallBid.Business.Modules.BodyTyperModule.Commands.BodyTypeEditCommand
{
    public class BodyTypeEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
