using Core.Utilities.Result.Abstract;
using NtierArchitecture.Entities.DTOs.ProductDTOs;
using System.Linq.Expressions;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IProductService
    {
        public Task<IDataResult<List<GetAllProductsDto>>> GetAllProductsAsync();
        public Task<IDataResult<GetProductDto>> GetProductByIdAsync(Guid id);
        public Task<IResult> AddProductAsync(CreateProductDto dto);
        public Task<IResult> DeleteProductAsync(Guid id);
    }
}
