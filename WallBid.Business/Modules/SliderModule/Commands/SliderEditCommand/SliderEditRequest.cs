using MediatR;
using Microsoft.AspNetCore.Http;

namespace WallBid.Business.Modules.SliderModule.Commands.SliderEditCommand
{
    public class SliderEditRequest : IRequest
    {
        public int Id { get; set; }
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
