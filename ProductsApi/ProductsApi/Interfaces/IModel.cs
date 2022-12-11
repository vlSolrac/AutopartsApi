using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface IModel
    {
        public Task<IActionResult> PostModel(ModelRequest model);
    }
}
