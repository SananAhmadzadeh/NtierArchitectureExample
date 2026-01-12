using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NtierArchitecture.Business.Services.Abstract;

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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllProductsAsync());
        }
    }
}
