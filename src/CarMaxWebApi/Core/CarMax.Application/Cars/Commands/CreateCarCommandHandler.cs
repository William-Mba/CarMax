using CarMax.Application.Interfaces;
using CarMax.Domain.Cars;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarMax.Application.Cars.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Car>
    {
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = request.Car;

            var createdCar = await _carRepository.CreateAsync(car);

            return createdCar;
        }
    }
}
