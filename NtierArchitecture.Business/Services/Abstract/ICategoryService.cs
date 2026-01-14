using NtierArchitecture.Entities.DTOs.CategoryDTOs;
using WebApiAdvanceExample.Entities.DTOs.CategoryDTOs;
using WebApiAdvanceExample.Entities.DTOs.ProductDTOs;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface ICategoryService
    {
        public Task<List<GetAllCategoriesDto>> GetAllCategoriesAsync();
        public Task<GetCategoryDto> GetCategoryByIdAsync(Guid id);
        public Task AddCategoryAsync(CreateCategoryDto dto);
        public Task DeleteCategoryAsync(Guid id);
    }
}
