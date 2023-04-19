using CarMax.Application.Cars.Commands;
using CarMax.Application.Cars.Queries;
using CarMax.Domain.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CarMax.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<CarsController>,
        [HttpPost]
        public async Task<Car> Post([FromBody] Car car)
        {
            var command = new CreateCarCommand { Car = car };

            var createdCar = await _mediator.Send(command);

            return createdCar;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public async Task<Car[]> Get()
        {
            var query = new GetAllCarsQuery();

            var cars = await _mediator.Send(query);

            return cars;
        }
    }
}
