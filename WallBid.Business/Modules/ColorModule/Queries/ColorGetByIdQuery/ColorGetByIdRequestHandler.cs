using MediatR;
using WallBid.Infrastructure.Dtos.Color;
using WallBid.Infrastructure.Exceptions;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ColorModule.Queries.ColorGetByIdQuery
{
    internal class ColorGetByIdRequestHandler : IRequestHandler<ColorGetByIdRequest, ColorGetByIdDto>
    {
        private readonly IColorRepository _colorRepository;
        public ColorGetByIdRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<ColorGetByIdDto> Handle(ColorGetByIdRequest request, CancellationToken cancellationToken)
        {
            var existData = _colorRepository.Get(m => m.DeletedBy == null && m.DeletedAt == null && m.Id == request.Id) ?? throw new NotFoundException("Data not found!");
            ColorGetByIdDto dto = new ColorGetByIdDto { Id = existData.Id, Name = existData.Name };
            return dto;
        }
    }
}
