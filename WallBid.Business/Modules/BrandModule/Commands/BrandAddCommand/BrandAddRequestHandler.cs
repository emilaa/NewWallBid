using MediatR;
using Microsoft.AspNetCore.Hosting;
using WallBid.Business.Extensions;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand
{
    internal class BrandAddRequestHandler : IRequestHandler<BrandAddRequest>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandAddRequestHandler(IBrandRepository brandRepository, IWebHostEnvironment webHostEnvironment)
        {
            _brandRepository = brandRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Handle(BrandAddRequest request, CancellationToken cancellationToken)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Logo.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);
            await request.Logo.SaveFileToLocalAsync(path);

            Brand brand = new()
            {
                Logo = fileName,
                Name = request.Name
            };

            _brandRepository.Add(brand);
            _brandRepository.Save();
        }
    }
}
