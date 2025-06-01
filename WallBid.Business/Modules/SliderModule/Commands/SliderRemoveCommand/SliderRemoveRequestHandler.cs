using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.SliderModule.Commands.SliderRemoveCommand
{
    internal class SliderRemoveRequestHandler : IRequestHandler<SliderRemoveRequest>
    {
        private readonly ISliderRepository _sliderRepository;

        public SliderRemoveRequestHandler(ISliderRepository sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public async Task Handle(SliderRemoveRequest request, CancellationToken cancellationToken)
        {
            var existData = _sliderRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.DeletedAt = DateTime.Now;
            _sliderRepository.Save();
        }
    }
}
