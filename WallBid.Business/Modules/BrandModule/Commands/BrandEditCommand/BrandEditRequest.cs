using MediatR;
using Microsoft.AspNetCore.Http;

namespace WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand
{
    public class BrandEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Logo { get; set; }

    }
}
