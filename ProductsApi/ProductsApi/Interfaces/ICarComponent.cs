using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface ICarComponent
    {
        public Task<IActionResult> PostCarComponent(CarComponentRequest carComponent);
    }
}
