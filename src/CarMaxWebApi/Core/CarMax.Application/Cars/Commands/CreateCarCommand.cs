using CarMax.Domain.Cars;
using MediatR;

namespace CarMax.Application.Cars.Commands
{
    public class CreateCarCommand : IRequest<Car>
    {
        public Car Car { get; set; } = null!;
    }
}
