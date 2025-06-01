using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ColorModule.Commands.ColorRemoveCommand
{
    internal class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest>
    {
        private readonly IColorRepository _colorRepository;

        public ColorRemoveRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var existData = _colorRepository.Get(m => m.DeletedAt == null && m.DeletedBy == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");

            existData.DeletedAt = DateTime.Now;
            _colorRepository.Save();
        }
    }
}
