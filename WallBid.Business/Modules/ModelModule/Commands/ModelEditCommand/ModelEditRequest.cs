using MediatR;

namespace WallBid.Business.Modules.ModelModule.Commands.ModelEditCommand
{
    public class ModelEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
