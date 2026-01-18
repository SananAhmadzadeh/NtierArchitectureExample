using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;
using WebApiAdvanceExample.Entities.DTOs.CategoryDTOs;

namespace ExampleWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]
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
            var result = await _service.GetAllCategoriesAsync();

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var result = await _service.GetCategoryByIdAsync(id);

            if (!result.Success)
                return NotFound(result); 

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto dto)
        {
            var result = await _service.AddCategoryAsync(dto);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _service.DeleteCategoryAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}
