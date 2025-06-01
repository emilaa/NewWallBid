using MediatR;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ColorModule.Commands.ColorAddCommand
{
    internal class ColorAddRequestHandler : IRequestHandler<ColorAddRequest>
    {
        private readonly IColorRepository _colorRepository;
        public ColorAddRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            Color color = new()
            {
                Name = request.Name,
            };
            _colorRepository.Add(color);
            _colorRepository.Save();
        }
    }
}
