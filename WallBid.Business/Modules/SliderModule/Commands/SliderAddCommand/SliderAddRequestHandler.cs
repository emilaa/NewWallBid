using MediatR;
using Microsoft.AspNetCore.Hosting;
using WallBid.Business.Extensions;
using WallBid.Business.Modules.CarModule.Commands.CarAddCommand;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.SliderModule.Commands.SliderAddCommand
{
    internal class SliderAddRequestHandler : IRequestHandler<SliderAddRequest>
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderAddRequestHandler(ISliderRepository sliderRepository, IWebHostEnvironment webHostEnvironment)
        {
            _sliderRepository = sliderRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Handle(SliderAddRequest request, CancellationToken cancellationToken)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Photo.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);
            await request.Photo.SaveFileToLocalAsync(path);

            Slider slider = new()
            {
                Image = fileName,
                Title = request.Title,
                Subtitle = request.Subtitle
            };

            _sliderRepository.Add(slider);
            _sliderRepository.Save();
        }
    }
}
