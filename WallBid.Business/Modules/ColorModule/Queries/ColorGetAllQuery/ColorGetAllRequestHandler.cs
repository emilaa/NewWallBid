using MediatR;
using WallBid.Infrastructure.Dtos.Color;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.ColorModule.Queries.ColorGetAllQuery
{
    internal class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<ColorGetAllDto>>
    {
        private readonly IColorRepository _colorRepository;
        public ColorGetAllRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<IEnumerable<ColorGetAllDto>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = _colorRepository.GetAll(m => m.DeletedAt == null && m.DeletedBy == null)
                .Select(m => new ColorGetAllDto { Id = m.Id, Name = m.Name });
            return data;
        }
    }
}
