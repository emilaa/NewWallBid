using MediatR;
using WallBid.Infrastructure.Dtos.Slider;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.SliderModule.Queries.SliderGetByIdQuery
{
    internal class SliderGetByIdRequestHandler : IRequestHandler<SliderGetByIdRequest, SliderGetByIdDto>
    {
        private readonly ISliderRepository _sliderRepository;
        public SliderGetByIdRequestHandler(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }
        public async Task<SliderGetByIdDto> Handle(SliderGetByIdRequest request, CancellationToken cancellationToken)
        {
            var existData = _sliderRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            var dto = new SliderGetByIdDto { Id = existData.Id, Title = existData.Title, Subtitle = existData.Subtitle, Image = existData.Image };
            return dto;
        }
    }
}
