using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Interfaces;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICar _car;

        public CarController(ICar car)
        {
            _car = car;
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CarRequest car)
        {
            return await _car.PostCar(car);
        }
    }
}
