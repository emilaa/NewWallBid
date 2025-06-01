using MediatR;
using WallBid.Infrastructure.Entities;
using WallBid.Infrastructure.Repositories;

namespace WallBid.Business.Modules.CarModule.Commands.CarAddCommand
{
    internal class CarAddRequestHandler : IRequestHandler<CarAddRequest>
    {
        private readonly ICarRepository _carRepository;

        public CarAddRequestHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(CarAddRequest request, CancellationToken cancellationToken)
        {
            Car car = new()
            {

            };

            _carRepository.Add(car);
            _carRepository.Save();
        }
    }
}
