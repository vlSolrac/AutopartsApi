using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Interfaces;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModel _model;

        public ModelController(IModel model)
        {
            _model = model;
        }

        [HttpPost]
        public async Task<IActionResult> PostModel([FromBody] ModelRequest model)
        {
            return await _model.PostModel(model);
        }
    }
}
