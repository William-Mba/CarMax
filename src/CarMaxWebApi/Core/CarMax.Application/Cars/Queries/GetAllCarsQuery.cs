using CarMax.Domain.Cars;
using MediatR;

namespace CarMax.Application.Cars.Queries
{
    public class GetAllCarsQuery : IRequest<Car[]>
    {
    }
}
