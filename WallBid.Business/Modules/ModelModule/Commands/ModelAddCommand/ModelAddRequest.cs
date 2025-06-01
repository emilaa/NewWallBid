using MediatR;

namespace WallBid.Business.Modules.ModelModule.Commands.ModelAddCommand
{
    public class ModelAddRequest : IRequest
    {

        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
