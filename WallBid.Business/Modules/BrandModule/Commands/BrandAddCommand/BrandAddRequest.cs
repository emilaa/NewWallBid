using MediatR;
using Microsoft.AspNetCore.Http;

namespace WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand
{
    public class BrandAddRequest : IRequest
    {
        public string Name { get; set; }
        public IFormFile Logo { get; set; }

    }
}
