using MediatR;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ColorModule.Commands.ColoEditCommand
{
    internal class ColorEditRequestHandler : IRequestHandler<ColorEditRequest>
    {
        private readonly IColorRepository _colorRepository;
        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var existData = _colorRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            existData.Name = request.Name;
            _colorRepository.Save();

        }
    }
}
