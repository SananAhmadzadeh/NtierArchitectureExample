using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;
using WebApiAdvanceExample.Entities.DTOs.CategoryDTOs;

namespace ExampleWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _service.GetAllCategoriesAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            return Ok(await _service.GetCategoryByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto dto)
        {
            await _service.AddCategoryAsync(dto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _service.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
