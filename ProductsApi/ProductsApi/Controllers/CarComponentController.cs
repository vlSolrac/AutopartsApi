using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Interfaces;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarComponentController : ControllerBase
    {
        private readonly ICarComponent _carComponent;

        public CarComponentController(ICarComponent carComponent)
        {
            _carComponent = carComponent;
        }

        [HttpPost]
        public async Task<IActionResult> PostCarComponents(CarComponentRequest carComponent)
        {
            return await _carComponent.PostCarComponent(carComponent);
        }
    }
}
