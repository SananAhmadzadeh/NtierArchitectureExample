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
            return Ok(await _service.GetAllProductsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _service.GetProductByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            await _service.AddProductAsync(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _service.DeleteProductAsync(id);
            return Ok();
        }
    }
}
