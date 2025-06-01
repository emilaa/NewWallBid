using MediatR;
using Microsoft.AspNetCore.Hosting;
using WallBid.Business.Extensions;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.SliderModule.Commands.SliderEditCommand
{
    internal class SliderEditRequestHandler : IRequestHandler<SliderEditRequest>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderEditRequestHandler(ISliderRepository sliderRepository, IWebHostEnvironment webHostEnvironment)
        {
            _sliderRepository = sliderRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Handle(SliderEditRequest request, CancellationToken cancellationToken)
        {
            var existData = _sliderRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.Image.DeleteImage(_webHostEnvironment.WebRootPath, "files");

            string fileName = Guid.NewGuid().ToString() + "-" + request.Photo.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);
            await request.Photo.SaveFileToLocalAsync(path);

            existData.Image = fileName;
            existData.Title = request.Title;
            existData.Subtitle = request.Subtitle;

            _sliderRepository.Save();
        }
    }
}
