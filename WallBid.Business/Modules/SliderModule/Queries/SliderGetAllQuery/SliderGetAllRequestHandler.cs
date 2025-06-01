using MediatR;
using WallBid.Infrastructure.Dtos.Slider;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.SliderModule.Queries.SliderGetAllQuery
{
    internal class SliderGetAllRequestHandler : IRequestHandler<SliderGetAllRequest, IEnumerable<SliderGetAllDto>>
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderGetAllRequestHandler(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public async Task<IEnumerable<SliderGetAllDto>> Handle(SliderGetAllRequest request, CancellationToken cancellationToken)
        {
            var datas = _sliderRepository.GetAll(m => m.DeletedAt == null && m.DeletedBy == null)
                .Select(m => new SliderGetAllDto { Id = m.Id, Image = m.Image, Title = m.Title, Subtitle = m.Subtitle });

            return datas;
        }
    }
}
