using Core.Utilities.Result.Abstract;
using NtierArchitecture.Entities.DTOs.CategoryDTOs;
using WebApiAdvanceExample.Entities.DTOs.CategoryDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface ICategoryService
    {
        public Task<IDataResult<List<GetAllCategoriesDto>>> GetAllCategoriesAsync();
        public Task<IDataResult<GetCategoryDto>> GetCategoryByIdAsync(Guid id);
        public Task<IResult> AddCategoryAsync(CreateCategoryDto dto);
        public Task<IResult> DeleteCategoryAsync(Guid id);
    }
}
