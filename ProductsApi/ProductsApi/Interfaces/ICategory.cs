using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Interfaces
{
    public interface ICategory
    {
        public Task<IActionResult> postCategory(Category category);
    }
}
