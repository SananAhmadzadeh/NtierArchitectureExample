using NtierArchitecture.Entities.DTOs.ProductDTOs;
using System.Linq.Expressions;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IProductService
    {
        public Task<List<GetAllProductsDto>> GetAllProductsAsync();
        public Task<GetProductDto> GetProductByIdAsync(Guid id);
        public Task AddProductAsync(CreateProductDto dto);
        public Task DeleteProductAsync(Guid id);
    }
}
