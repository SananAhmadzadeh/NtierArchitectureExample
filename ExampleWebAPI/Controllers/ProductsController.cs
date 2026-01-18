using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace ExampleWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _service.GetAllProductsAsync();

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _service.GetProductByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            var result = await _service.AddProductAsync(dto);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _service.DeleteProductAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}
