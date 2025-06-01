using MediatR;
using Microsoft.AspNetCore.Http;

namespace WallBid.Business.Modules.CarModule.Commands.CarAddCommand
{
    public class SliderAddRequest : IRequest
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
