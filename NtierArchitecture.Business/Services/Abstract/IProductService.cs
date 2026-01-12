using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IProductService
    {
        public Task<List<GetProductDto>> GetAllProductsAsync();
    }
}
