using MediatR;
using Microsoft.AspNetCore.Hosting;
using WallBid.Business.Extensions;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.BrandModule.Commands.BrandAddCommand
{
    internal class BrandEditRequestHandler : IRequestHandler<BrandEditRequest>
    {
        public readonly IBrandRepository _brandRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandEditRequestHandler(IBrandRepository brandRepository, IWebHostEnvironment webHostEnvironment)
        {
            _brandRepository = brandRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Handle(BrandEditRequest request, CancellationToken cancellationToken)
        {
            var existData = _brandRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            existData.Logo.DeleteImage(_webHostEnvironment.WebRootPath, "files");

            string fileName = Guid.NewGuid().ToString() + "-" + request.Logo.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);
            await request.Logo.SaveFileToLocalAsync(path);

            existData.Logo = fileName;
            existData.Name = request.Name;


            _brandRepository.Save();
        }
    }
}
