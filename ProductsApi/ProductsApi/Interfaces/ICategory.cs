using Microsoft.AspNetCore.Mvc;
using ProductsApi.DTO;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface ICategory
    {
        public Task<IActionResult> PostCategory(CategoryRequest category);
    }
}
