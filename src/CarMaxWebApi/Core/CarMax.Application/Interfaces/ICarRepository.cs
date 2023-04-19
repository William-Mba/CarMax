using CarMax.Domain.Cars;

namespace CarMax.Application.Interfaces
{
    public interface ICarRepository : IRepositoryAsync<Car>
    {
    }
}
