using CarMax.Application.Interfaces;
using CarMax.Domain.Cars;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarMax.Application.Cars.Queries
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, Car[]>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car[]> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync();

            return cars.ToArray();
        }
    }
}
