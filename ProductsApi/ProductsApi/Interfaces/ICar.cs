using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface ICar
    {
        public Task<IActionResult> PostCar(CarRequest car);
    }
}
